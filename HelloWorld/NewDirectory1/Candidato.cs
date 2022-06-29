namespace HelloWorld.NewDirectory1;

public class Candidato
{
    public string Nombre { get; set; }

    public int Votos { get; set; }

    public Candidato(string nombre)
    {
        this.Nombre = nombre;
    }

    public void AumentarVoto()
    {
        Votos++;
    }
}