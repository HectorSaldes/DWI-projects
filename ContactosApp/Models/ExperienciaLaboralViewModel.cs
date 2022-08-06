using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContactosApp.Models;

public class ExperienciaLaboralViewModel : ExperienciaLaboral
{
    // Select
    public IEnumerable<ExperienciaLaboral>? ExperenciasLaborales { get; set; }
    public IEnumerable<SelectListItem>? TiposEmpleos { get; set; }
    public IEnumerable<SelectListItem>? EntidadesFederativas { get; set; }
    
    public bool FlagModalError { get; set; }
}