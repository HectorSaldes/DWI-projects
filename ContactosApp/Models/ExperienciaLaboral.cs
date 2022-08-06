using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ContactosApp.Models;

public class ExperienciaLaboral
{
    public long Id { get; set; }

    [DisplayName(displayName: "Cargo: ")] // se muestra en el label este nombre de HTML
    [Required(ErrorMessage = "El {0} es obligatorio")]
    [StringLength(maximumLength: 60, MinimumLength = 2, ErrorMessage = "El {0} debe estar entre {1} y {2} letras")]
    public string? Cargo { get; set; }

    [DisplayName(displayName: "Nombre de la empresa: ")] // se muestra en el label este nombre de HTML
    [Required(ErrorMessage = "El {0} es obligatorio")]
    [StringLength(maximumLength: 60, MinimumLength = 2, ErrorMessage = "El {0} debe estar entre {1} y {2} letras")]
    public string? NombreEmpresa { get; set; }

    [DisplayName(displayName: "Descripción: ")] // se muestra en el label este nombre de HTML
    [Required(ErrorMessage = "La {0} es obligatoria")]
    [StringLength(maximumLength: 100, MinimumLength = 0, ErrorMessage = "El {0} debe estar entre {1} y {2} letras")]
    public string? Descripcion { get; set; }
    
    public long TipoEmpleoId { get; set; }
    public string? TipoEmpleo { get; set; }
    public long EntidadFederativaId { get; set; }
    public string? EntidadFederativa { set; get; }
}
