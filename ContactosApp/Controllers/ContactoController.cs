using ContactosApp.Models;
using ContactosApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactosApp.Controllers;

public class ContactoController : Controller
{
    private readonly ILogger<ContactoController> _logger;
    private readonly IContactoRepository _contactoRepository;


    public ContactoController(ILogger<ContactoController> logger, IContactoRepository contactoRepository)
    {
        _logger = logger;
        _contactoRepository = contactoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var modelo = await ObtenerContactoViewModel();
        /*var listaContactos = await _contactoRepository.Listar();
        var modelo = new ContactoViewModel() { Contactos = listaContactos };*/
        return View(modelo);
    }

    [HttpPost]
    public async Task<IActionResult> Contacto(Contacto contacto)
    {
        if (!ModelState.IsValid)
        {
            // Si ocurre un error en el Modal, enviamos los datos al modal para no perderlos y pueda seguir ingresando la información.
            // var modelo = new ContactoViewModel();
            var modelo = await ObtenerContactoViewModel();
            modelo.Contactos = await _contactoRepository.Listar();
            modelo.Nombre = contacto.Nombre;
            modelo.Edad = contacto.Edad;
            modelo.Telefono = contacto.Telefono;
            modelo.CorreoElectronico = contacto.CorreoElectronico;
            modelo.FlagModalError = true;
            return View("Index", modelo); // La vista index enviamos nuestro modelo y se pinta en el formulario
        }

        await _contactoRepository.Registrar(contacto);
        return RedirectToAction("Index");
    }

    private async Task<ContactoViewModel> ObtenerContactoViewModel()
    {
        // var modelo = new ContactoViewModel(){Contactos = await _contactoRepository.Listar()};
        // modelo.Contactos = await _contactoRepository.Listar();
        // return modelo;
        return new ContactoViewModel() { Contactos = await _contactoRepository.Listar() };
    }

    [HttpGet]
    public async Task<IActionResult> Actualizar(int id)
    {
        var contacto = await _contactoRepository.BuscarPorId(id);
        if (contacto is null)
        {
            return RedirectToAction("Index");
        }

        return View(contacto);
    }

    [HttpPost]
    public async Task<IActionResult> Actualizar(Contacto contacto)
    {
        var existeContacto = await _contactoRepository.BuscarPorId(contacto.Id);
        if (existeContacto is null)
        {
            return RedirectToAction("Index");
        }

        await _contactoRepository.Actualizar(contacto);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Eliminar(int id)
    {
        var existeContacto = await _contactoRepository.BuscarPorId(id);
        if (existeContacto is null)
        {
            return RedirectToAction("Index");
        }

        await _contactoRepository.Eliminar(id);
        return RedirectToAction("Index");
    }

    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> VerificarExisteCorreo(string correoElectronico, int id)
    {
        var existeCorreo = await _contactoRepository.VerificarExisteCorreo(correoElectronico, id);
        if (existeCorreo)
        {
            return Json($"El correo {correoElectronico} ya ha sido registrado.");
        }

        return Json(true);
    }

    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> VerificarExisteTelefono(string telefono, int id)
    {
        var existeCorreo = await _contactoRepository.VerificarExisteTelefono(telefono, id);
        if (existeCorreo)
        {
            return Json($"El correo {telefono} ya ha sido registrado.");
        }

        return Json(true);
    }
}