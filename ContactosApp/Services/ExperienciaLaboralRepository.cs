using ContactosApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ContactosApp.Services;

public interface IExperienciaLaboralRepository
{
    Task Registrar(ExperienciaLaboral experienciaLaboral);
    Task Actualizar(ExperienciaLaboral experienciaLaboral);
    Task<IEnumerable<ExperienciaLaboral>> Listar();
    Task<ExperienciaLaboral> BuscarPorId(long id);
    Task Eliminar(int id);
}

public class ExperienciaLaboralRepository : IExperienciaLaboralRepository
{
    private readonly string _connectionString;

    public ExperienciaLaboralRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task Registrar(ExperienciaLaboral experienciaLaboral)
    {
        using var connection = new SqlConnection(_connectionString);
        var id = await connection.QuerySingleAsync<long>(
            @"INSERT INTO ExperienciaLaboral(Cargo, NombreEmpresa, Descripcion, TipoEmpleoId, EntidadFederativaId)
                 VALUES (@Cargo, @NombreEmpresa, @Descripcion, @TipoEmpleoId, @EntidadFederativaId);SELECT SCOPE_IDENTITY();",
            experienciaLaboral);
        experienciaLaboral.Id = id;
    }

    public async Task Actualizar(ExperienciaLaboral experienciaLaboral)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(@"
                UPDATE ExperienciaLaboral
                SET Cargo = @Cargo, NombreEmpresa = @NombreEmpresa, Descripcion = @Descripcion,
                    TipoEmpleoId =@TipoEmpleoId, EntidadFederativaId = @EntidadFederativaId
                WHERE Id = @Id;
        ", experienciaLaboral);
    }

    public async Task<ExperienciaLaboral> BuscarPorId(long id)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<ExperienciaLaboral>(
            @"SELECT x.Id, x.Cargo, x.Cargo, x.Descripcion, x.NombreEmpresa ,
                    t.Id AS TipoEmpleoId, t.Nombre AS TipoEmpleo,
                    e.Nombre AS EntidadFederativa, e.Id AS EntidadFederativaId
                    FROM ExperienciaLaboral AS x
                    INNER JOIN TipoEmpleo AS t on x.TipoEmpleoId = t.Id
                    INNER JOIN EntidadFederativa e on e.Id = x.EntidadFederativaId
                WHERE X.Id = @Id", new { id });
    }

    public async Task Eliminar(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync($@"DELETE FROM ExperienciaLaboral WHERE Id = @Id", new { id });
    }

    public async Task<IEnumerable<ExperienciaLaboral>> Listar()
    {
        using var connection = new SqlConnection(_connectionString);
        return await
            connection.QueryAsync<ExperienciaLaboral>( // as Tipo Empleo para que haga match con nuestro atributo
                @"SELECT x.Id, x.Cargo, x.Cargo, x.Descripcion, x.NombreEmpresa ,
                        t.Nombre AS TipoEmpleo, 
                        e.Nombre AS EntidadFederativa
                    FROM ExperienciaLaboral AS x
                    INNER JOIN TipoEmpleo AS t on x.TipoEmpleoId = t.Id
                    INNER JOIN EntidadFederativa e on e.Id = x.EntidadFederativaId");
    }
}