using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExperienciaApp.Models;

namespace ExperienciaApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProyectoRepository _proyectoRepository;
    private readonly IHabilidadRepository _habilidadRepository;
    private readonly IContactoRepository _contactoRepository;

    // Inyección de dependencias
    public HomeController(ILogger<HomeController> logger, IProyectoRepository proyectoRepository,
        IHabilidadRepository habilidadRepository, IContactoRepository contactoRepository)
    {
        _logger = logger;
        _proyectoRepository = proyectoRepository;
        _habilidadRepository = habilidadRepository;
        _contactoRepository = contactoRepository;
    }

    public IActionResult Index()
    {
        // Uso de los logs
        _logger.LogInformation("Information en Index");
        _logger.LogError("Error en Index");
        _logger.LogCritical("Critico en Index");
        _logger.LogDebug("Debug en Index");
        _logger.LogTrace("Trace en Index");
        _logger.LogWarning("Warning en Index");

        var builder = WebApplication.CreateBuilder();
        var directorio = builder.Configuration.GetValue<String>("directorio");
        _logger.LogWarning($"Directorio: {directorio}");

        var proyectos = _proyectoRepository.ObtenerProyectos().ToList();
        var habilidades = _habilidadRepository.ObtenerHabilidades().ToList();
        var model = new HomeIndexViewModel() { Proyectos = proyectos, Habilidades = habilidades };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Contacto()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contacto(Contacto contacto)
    {
        if (!ModelState.IsValid)
            return View();
        else
        {
            await _contactoRepository.Registrar(contacto);
            return RedirectToAction("Listar");
        }
    }

    public async Task<IActionResult> Listar()
    {
        var listaContactos = await _contactoRepository.Listar();
        return View(listaContactos);
    }


    // No se usa porque ya esta en el repository
    private List<Proyecto> ObtenerProyectos()
    {
        return new List<Proyecto>()
        {
            new Proyecto
            {
                Nombre = "SISA",
                Descripcion = "Sistema Integral de Servicios Administativos",
                Enlace = "https://srvcldutez.utez.edu.mx:8443/SISAVA/",
                Imagen = "img1.png"
            },
            new Proyecto
            {
                Nombre = "Amazon",
                Descripcion = "Plataforma de ecommerce online",
                Enlace = "https://www.amazon.com.mx",
                Imagen = "img2.png"
            },
        };
    }

// No se usa porque ya esta en el repository
    private List<Habilidad> ObtenerHabilidades()
    {
        return new List<Habilidad>()
        {
            new Habilidad()
            {
                Nombre = "Administración de base de datos"
            },
            new Habilidad()
            {
                Nombre = "Desarrollo de aplicaciones web con Spring boot"
            }
        };
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}