namespace ExperienciaApp.Models;

public interface IProyectoRepository
{
    List<Proyecto> ObtenerProyectos();
}

public class ProyectoRepository : IProyectoRepository
{
    public List<Proyecto> ObtenerProyectos()
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
}