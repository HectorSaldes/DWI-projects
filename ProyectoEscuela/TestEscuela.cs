using System;

namespace escuela
{
    public class TestEscuela
    {
        static void Main(string[] args)
        {
            Carrera Tic = new Carrera();
            Tic.Id = 1;
            Tic.Nombre = "TIC";

            Estudiante Hector = new Estudiante();
            Hector.Id = 1;
            Hector.Nombre = "Hector";
            Hector.Carrera = Tic;
            
            Console.WriteLine($"Hola {Hector.Nombre}, con carrera {Hector.Carrera.Nombre}");
        }
    }
}