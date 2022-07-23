namespace ContactosApp.Models;

public class ExperienciaLaboral
{
    public long Id { get; set; }
    public string? Cargo { get; set; }
    public string? NombreEmpresa { get; set; }
    public string? Descripcion { get; set; }
    public long TipoEmpleoId { get; set; }
    public long EntidadFederativaId { get; set; }
}