namespace ExperienciaApp.Models;

public interface IHabilidadRepository
{
    List<Habilidad> ObtenerHabilidades();
}


public class HabilidadRepository : IHabilidadRepository
{
    public List<Habilidad> ObtenerHabilidades()
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
            },  new Habilidad()
            {
                Nombre = "Tester de aplicaciones"
            },
        };
    }
}