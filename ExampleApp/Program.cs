var builder = WebApplication.CreateBuilder(args);

// Agregar el tema de los servicios
var services = builder.Services;
services.AddMvc();

var app = builder.Build();

// Redireccionamiento
app.UseHttpsRedirection();

// Middleware
app.UseStaticFiles(); // Habilitar la carpeta wwwroot
app.UseDefaultFiles();


// Acceder a rutas
app.UseRouting();

//app.MapGet("/", () => "Hola mundo desde la utez");
//app.MapGet("/test", () => "Esto es un testeo");

// Usar la autorización
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=App}/{action=Index}/{id?}"
);


app.Run();
