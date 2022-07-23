using ContactosApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactosApp.Controllers;

public class ExperienciaLaboralController : Controller
{
    private readonly ILogger<ExperienciaLaboralController> _logger;
    private readonly IEntidadFederativaRepository _entidadFederativaRepository;
    private readonly IExperienciaLaboralRepository _experienciaLaboralRepository;
    private readonly ITipoEmpleoRepository _tipoEmpleoRepository;

    public ExperienciaLaboralController(
        ILogger<ExperienciaLaboralController> logger,
        IEntidadFederativaRepository entidadFederativaRepository,
        IExperienciaLaboralRepository experienciaLaboralRepository,
        ITipoEmpleoRepository tipoEmpleoRepository
    )
    {
        _logger = logger;
        _entidadFederativaRepository = entidadFederativaRepository;
        _experienciaLaboralRepository = experienciaLaboralRepository;
        _tipoEmpleoRepository = tipoEmpleoRepository;
    }
}