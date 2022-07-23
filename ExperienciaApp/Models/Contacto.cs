using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExperienciaApp.Models
{
    public class Contacto : IValidatableObject
    {
        public int Id { get; set; }

        [DisplayName(displayName: "Nombre de la persona")] // se muestra en el label este nombre
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "El {0} debe estar entre 2 y 50 letras")]
        public string? Nombre { get; set; }

        [DisplayName(displayName: "Edad de la persona")]
        [Required(ErrorMessage = "La {0} es obligatoria")]
        [Range(minimum: 1, maximum: 120, ErrorMessage = "Solo se admiten valores entre 1 y 120")]
        public int? Edad { get; set; }

        [DisplayName(displayName: "Correo electónico de la persona")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [EmailAddress(ErrorMessage = "Utiliza un formado de correo válido")]
        public string? CorreoElectronico { get; set; }

        [DisplayName(displayName: "Teléfono de la persona")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        [RegularExpression("^[0-9]+")]
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
}
 
