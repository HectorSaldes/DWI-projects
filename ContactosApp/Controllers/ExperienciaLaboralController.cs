using AutoMapper;
using ContactosApp.Models;
using ContactosApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContactosApp.Controllers;

public class ExperienciaLaboralController : Controller
{
    private readonly ILogger<ExperienciaLaboralController> _logger;
    private readonly IEntidadFederativaRepository _entidadFederativaRepository;
    private readonly IExperienciaLaboralRepository _experienciaLaboralRepository;
    private readonly ITipoEmpleoRepository _tipoEmpleoRepository;
    private readonly IMapper _mapper;

    public ExperienciaLaboralController(
        ILogger<ExperienciaLaboralController> logger,
        IEntidadFederativaRepository entidadFederativaRepository,
        IExperienciaLaboralRepository experienciaLaboralRepository,
        ITipoEmpleoRepository tipoEmpleoRepository,
        IMapper mapper
    )
    {
        _logger = logger;
        _entidadFederativaRepository = entidadFederativaRepository;
        _experienciaLaboralRepository = experienciaLaboralRepository;
        _tipoEmpleoRepository = tipoEmpleoRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var modelo = await ObtenerExperienciasLaboralesViewModel(new ExperienciaLaboral());
        return View(modelo);
    }


    [HttpGet]
    public async Task<IActionResult> Actualizar(long id)
    {
        var experienciaLaboral = await _experienciaLaboralRepository.BuscarPorId(id);
        if (experienciaLaboral is null)
            return RedirectToAction("Index");

        var modelo = await ObtenerExperienciasLaboralesViewModel(experienciaLaboral);
        /* El AutoMapper realiza esto en automático:
         modelo.EntidadesFederativas = await ObtenerEntidadesFederativas();
        modelo.TiposEmpleos = await ObtenerTiposEmpleos();
        modelo.Id = experienciaLaboral.Id;
        modelo.Cargo = experienciaLaboral.Cargo;
        modelo.Descripcion = experienciaLaboral.Descripcion;
        modelo.NombreEmpresa = experienciaLaboral.NombreEmpresa;
        modelo.EntidadFederativaId = experienciaLaboral.EntidadFederativaId;
        modelo.TipoEmpleoId = experienciaLaboral.TipoEmpleoId;*/
        return View(modelo);
    }

    [HttpPost]
    public async Task<IActionResult> Actualizar(ExperienciaLaboral experienciaLaboral)
    {
        if (!ModelState.IsValid)
        {
            var modelo = await ObtenerExperienciasLaboralesViewModel(experienciaLaboral);
            /* El AutoMapper realiza esto en automático:
             modelo.Id = experienciaLaboral.Id;
            modelo.Cargo = experienciaLaboral.Cargo;
            modelo.Descripcion = experienciaLaboral.Descripcion;
            modelo.NombreEmpresa = experienciaLaboral.NombreEmpresa;
            modelo.EntidadFederativaId = experienciaLaboral.EntidadFederativaId;
            modelo.TipoEmpleoId = experienciaLaboral.TipoEmpleoId;*/
            return View(modelo);
        }

        var existeExperencia = await _experienciaLaboralRepository.BuscarPorId(experienciaLaboral.Id);
        if (existeExperencia is null)
        {
            return RedirectToAction("Index");
        }

        await _experienciaLaboralRepository.Actualizar(experienciaLaboral);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(ExperienciaLaboral experienciaLaboral)
    {
        if (!ModelState.IsValid)
        {
            var modelo = await ObtenerExperienciasLaboralesViewModel(experienciaLaboral);
            modelo.FlagModalError = true;
            /* El AutoMapper realiza esto en automático:
            modelo.Cargo = experienciaLaboral.Cargo;
            modelo.NombreEmpresa = experienciaLaboral.NombreEmpresa;
            modelo.Descripcion = experienciaLaboral.Descripcion;
            modelo.TipoEmpleoId = experienciaLaboral.TipoEmpleoId;
            modelo.EntidadFederativaId = experienciaLaboral.EntidadFederativaId;*/
            return View("Index", modelo);
        }
        await _experienciaLaboralRepository.Registrar(experienciaLaboral);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Eliminar(int id)
    {
        await _experienciaLaboralRepository.Eliminar(id);
        return RedirectToAction("Index");
    }

    private async Task<ExperienciaLaboralViewModel> ObtenerExperienciasLaboralesViewModel(
        ExperienciaLaboral experienciaLaboral)
    {
        var modelo = _mapper.Map<ExperienciaLaboralViewModel>(experienciaLaboral);
        modelo.ExperenciasLaborales = await _experienciaLaboralRepository.Listar();
        modelo.TiposEmpleos = await ObtenerTiposEmpleos();
        modelo.EntidadesFederativas = await ObtenerEntidadesFederativas();
        return modelo;
    }

    private async Task<IEnumerable<SelectListItem>> ObtenerTiposEmpleos()
    {
        var tiposEmpleos = await _tipoEmpleoRepository.Listar();
        return tiposEmpleos.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
    }

    private async Task<IEnumerable<SelectListItem>> ObtenerExperienciasLaborales()
    {
        var experienciasLaborales = await _experienciaLaboralRepository.Listar();
        return experienciasLaborales.Select(x => new SelectListItem(x.Cargo, x.Id.ToString()));
    }

    private async Task<IEnumerable<SelectListItem>> ObtenerEntidadesFederativas()
    {
        var entidadesFederativas = await _entidadFederativaRepository.Listar();
        return entidadesFederativas.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
    }
}