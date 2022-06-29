/*
  - Saldaña Espinoza Hector
  - Desarrollo web integral
  - 9B
*/
public class Candidato
{
    public string Nombre { get; set; }

    public int Votos { get; set; }

    public Candidato(string nombre)
    {
        Nombre = nombre;
        Votos = 0;
    }

    public void AumentarVoto()
    {
        Votos++;
    }
}