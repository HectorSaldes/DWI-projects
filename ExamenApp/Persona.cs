namespace ExamenApp;

public class Persona
{
    private string Nombre;
    private int Edad;

    private float Estatura;

    private char Sexo;

    private bool EstadoCivil;

    public Persona(string nombre, int edad, float estatura, char sexo, bool estadocivil)
    {
        Nombre = nombre;
        Edad = edad;
        Estatura = estatura;
        Sexo = sexo;
        EstadoCivil = estadocivil;
    }

    public void GetAllData()
    {
        string genero, estado;
        if (Sexo == 'H' || Sexo == 'h') genero = "Hombre"; else genero = "Mujer";
        if (EstadoCivil) estado = "Casado"; else estado = "Soltero";
        // Console.WriteLine("Hola como estas " + (EstadoCivil ? "Casado" : "Soltero"));
        Console.WriteLine($"NOMBRE:{Nombre}\nEDAD: {Edad} AÑOS\nESTATURA: {Estatura}\nSEXO: {genero}\nESTADO CIVIL: {estado}");
    }

    public string GetNombre() { return Nombre; }

    public int GetEdad() { return Edad; }

    public float GetEstatura() { return Estatura; }

    public char GetSexo() { return Sexo; }

    public bool GetEstadoCivil() { return EstadoCivil; }

    public void SetNombre(string nombre) { Nombre = nombre; }

    public void SetEdad(int edad) { Edad = edad; }

    public void SetEstatura(float estatura) { Estatura = estatura; }

    public void SetSexo(char sexo) { Sexo = sexo; }
    public void SetEstadoCivil(bool estadoCivil) { EstadoCivil = estadoCivil; }


}