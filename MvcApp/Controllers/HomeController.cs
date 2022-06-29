using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Personal()
    {
        ViewBag.Nombre = "Hector";
        ViewBag.Apellidos = "Saldaña Espinoza";
        ViewBag.Edad = 21;
        ViewBag.Correo = "20193tn070@utez.edu.mx";
        ViewBag.Telefono = "7772003900";
        return View();
    }
    public IActionResult Carrera()
    {
        ViewBag.Carrera ="Ingeniería en desarrollo y gestión de software";
        ViewBag.Imagen ="inge.jpg";
        return View();
    }
    public IActionResult Pasatiempo()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        // retornarlo a una vista diferente
        ViewBag.Nombre = "Hector Saldaña Espinoza"; // Enviar datos a la vista
        ViewBag.Lady = "";
        return View("Privacy2");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
