using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ContactosApp.Models;

public class Contacto
{
    public int Id { get; set; }

    [DisplayName(displayName: "Nombre: ")] // se muestra en el label este nombre de HTML
    [Required(ErrorMessage = "El {0} es obligatorio")]
    [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "El {0} debe estar entre {1} y {2} letras")]
    public string? Nombre { get; set; }

    [DisplayName(displayName: "Edad: ")]
    [Required(ErrorMessage = "La {0} es obligatoria")]
    [Range(minimum: 1, maximum: 120, ErrorMessage = "Solo se admiten valores entre {1} y {2}")]
    public int? Edad { get; set; }

    [DisplayName(displayName: "Correo electónico: ")]
    [Required(ErrorMessage = "El {0} es obligatorio")]
    [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "El {0} debe estar entre {1} y {2} letras")]
    [EmailAddress(ErrorMessage = "Utiliza un formado de correo válido")]
    [Remote(action: "VerificarExisteCorreo", controller: "Contacto", AdditionalFields = nameof(Id))]
    public string? CorreoElectronico { get; set; }

    [DisplayName(displayName: "Teléfono: ")]
    [Required(ErrorMessage = "El {0} es obligatorio")]
    [StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "El {0} debe estar entre {1} y {2} dígitos")]
    [RegularExpression("^[0-9]+")]
    [Remote(action: "VerificarExisteTelefono", controller: "Contacto", AdditionalFields = nameof(Id))]
    public string? Telefono { get; set; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Nombre != null && Nombre.Length > 0)
        {
            var primeraLetra = Nombre[0].ToString();
            if (primeraLetra != primeraLetra.ToUpper())
            {
                yield return new ValidationResult("La primera letra debe ser mayúscula", new[] { nameof(Nombre) });
            }
        }
    }
}