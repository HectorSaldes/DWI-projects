using ContactosApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ContactosApp.Services;


public interface ITipoEmpleoRepository
{
    Task Registrar(TipoEmpleo contacto);
    Task<IEnumerable<TipoEmpleo>> Listar();
    Task Actualizar(TipoEmpleo contacto);
    Task<TipoEmpleo> BuscarPorId(int id);
    Task Eliminar(long id);
}

public class TipoEmpleoRepository :ITipoEmpleoRepository
{
    private readonly string _connectionString;

    public TipoEmpleoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public async Task Registrar(TipoEmpleo contacto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TipoEmpleo>> Listar()
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<TipoEmpleo>($@"SELECT * FROM TipoEmpleo;");
    }

    public async Task Actualizar(TipoEmpleo contacto)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(
            $@"UPDATE TipoEmpleo SET Nombre = @Nombre WHERE Id = @Id;",
            contacto);
    }

    public async Task<TipoEmpleo> BuscarPorId(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstAsync<TipoEmpleo>($@"SELECT * FROM TipoEmpleo  WHERE Id = @Id", new { id });
    }

    public async Task Eliminar(long id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync($@"DELETE FROM TipoEmpleo WHERE Id = @Id", new { id });
    }
}