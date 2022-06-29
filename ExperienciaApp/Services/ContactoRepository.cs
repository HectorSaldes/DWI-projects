using Dapper;
using ExperienciaApp.Models;
using Microsoft.Data.SqlClient;

public interface IContactoRepository
{
    // Implementar método asícncrono
    Task Registrar(Contacto contacto);
    Task<IEnumerable<Contacto>> Listar();
}


public class ContactoRepository : IContactoRepository
{
    private readonly string _connectionString;

    public ContactoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnections");
    }

    public async Task Registrar(Contacto contacto)
    {
        using var connection = new SqlConnection(_connectionString);
        // var id = connection.QuerySingle<int>($@"INSERT INTO Contacto(Nombre, CorreoElectronico, Telefono, Edad) VALUES (@Nombre, @CorreoElectronico, @Telefono, @Edad); SELECT SCOPE_IDENTITY(); ", contacto);
        var id = await connection.QuerySingleAsync<int>($@"INSERT INTO Contacto(Nombre, CorreoElectronico, Telefono, Edad) VALUES (@Nombre, @CorreoElectronico, @Telefono, @Edad); SELECT SCOPE_IDENTITY(); ", contacto);
        Console.WriteLine($"ID DE LA INSERCIÓN: {id}");
    }

    public async Task<IEnumerable<Contacto>> Listar()
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Contacto>($@"SELECT Nombre, CorreoElectronico, Telefono, Edad FROM Contacto;");
    }
}