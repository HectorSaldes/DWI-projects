using ContactosApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ContactosApp.Services;

public interface IContactoRepository
{
    Task Registrar(Contacto contacto);
    Task<IEnumerable<Contacto>> Listar();
    Task Actualizar(Contacto contacto);
    Task<Contacto> BuscarPorId(int id);
    Task Eliminar(int id);
    Task<bool> VerificarExisteCorreo(string? correoElectronico, int? id);

    Task<bool> VerificarExisteTelefono(string? telefono, int? id);
}

public class ContactoRepository : IContactoRepository
{
    private readonly string _connectionString;

    public ContactoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task Registrar(Contacto contacto)
    {
        using var connection = new SqlConnection(_connectionString);
        var id = await connection.QuerySingleAsync<int>(
            $@"INSERT INTO Contacto(Nombre, CorreoElectronico, Telefono, Edad) VALUES (@Nombre, @CorreoElectronico, @Telefono, @Edad); SELECT SCOPE_IDENTITY(); ",
            contacto);
        Console.WriteLine($"ID DE LA INSERCIÓN: {id}");
    }


    public async Task<IEnumerable<Contacto>> Listar()
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Contacto>($@"SELECT * FROM Contacto;");
    }

    public async Task Actualizar(Contacto contacto)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(
            $@"UPDATE Contacto SET Nombre = @Nombre, Edad = @Edad, CorreoElectronico = @CorreoElectronico, Telefono = @Telefono WHERE Id = @Id;",
            contacto);
    }

    public async Task<Contacto> BuscarPorId(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstAsync<Contacto>($@"SELECT * FROM Contacto  WHERE Id = @Id", new { id });
    }

    public async Task Eliminar(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync($@"DELETE FROM Contacto WHERE Id = @Id", new { id });
    }

    public async Task<bool> VerificarExisteCorreo(string? correoElectronico, int? id)
    {
        using var connection = new SqlConnection(_connectionString);
        var existeCorreo = await connection.QueryFirstOrDefaultAsync<int>(
            $@"SELECT 1 FROM Contacto WHERE CorreoElectronico = @CorreoElectronico AND Id <> @Id;", new { correoElectronico, id });
        return existeCorreo == 1;
    }

    public async Task<bool> VerificarExisteTelefono(string? telefono, int? id)
    {
        using var connection = new SqlConnection(_connectionString);
        var existeTelefono = await connection.QueryFirstOrDefaultAsync<int>(
            $@"SELECT 1 FROM Contacto WHERE Telefono = @Telefono AND Id <> @Id;", new { telefono, id });
        return existeTelefono == 1;
    }
}