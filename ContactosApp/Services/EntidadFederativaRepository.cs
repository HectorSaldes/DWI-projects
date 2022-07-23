using ContactosApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ContactosApp.Services;

public interface IEntidadFederativaRepository
{
    Task<IEnumerable<EntidadFederativa>> Listar();
    Task<EntidadFederativa> BuscarPorId(long id);
}

public class EntidadFederativaRepository : IEntidadFederativaRepository
{
    private readonly string _connectionString;

    public EntidadFederativaRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public async Task<IEnumerable<EntidadFederativa>> Listar()
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<EntidadFederativa>($@"SELECT * FROM EntidadFederativa;");
    }

    public async Task<EntidadFederativa> BuscarPorId(long id)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstAsync<EntidadFederativa>($@"SELECT * FROM EntidadFederativa  WHERE Id = @Id", new { id });

    }
}