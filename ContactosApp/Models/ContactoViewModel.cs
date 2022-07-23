namespace ContactosApp.Models;

public class ContactoViewModel : Contacto
{
    public IEnumerable<Contacto>? Contactos { get; set; }
    public bool FlagModalError { get; set; }
}