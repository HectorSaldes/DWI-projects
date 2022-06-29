using System.Text.RegularExpressions;
/*
  - Saldaña Espinoza Hector
  - Desarrollo web integral
  - 9B
*/
public class TestCandidatos
{
    private const string CONTRASENA = "DM";
    private const int NOCANDIDATOS = 3;

    static void Main()
    {
        InicioElecciones();
    }

    static void InicioElecciones()
    {
        bool flag = true;
        Candidato[] candidatos = IniciarCandidatos();
        do
        {
            int i, opc;
            Console.WriteLine("\n\tMENÚ SELECCIONES 2022 EMILIANO ZAPATA POR LA JUSTICIA DE LA BENITO");
            for (i = 0; i < candidatos.Length; i++) Console.WriteLine($"{i + 1}. Votar por el candidato: {candidatos[i].Nombre}");
            Console.WriteLine($"{i + 1}. Cerrar casillas");
            opc = ObtenerNumero("Elija una opción: ");
            switch (opc)
            {
                case > 0 and <=NOCANDIDATOS:
                {
                    candidatos[opc - 1].AumentarVoto();
                    Console.WriteLine("\n-------------------------------------------------------------");
                    Console.WriteLine($"\tVOTO REALIZADO CORRECTAMENTE PARA: {candidatos[opc - 1].Nombre}");
                    Console.WriteLine("-------------------------------------------------------------");
                    break;
                }
                case 4:
                {
                    if (CerrarElecciones())
                    {
                        flag = false;
                        MostrarResultados(candidatos);
                    }
                    else
                    {
                        Console.WriteLine("\n-------------------------------------------------------------");
                        Console.WriteLine("\tESAS NO FUERON LAS CONTRASEÑAS CORRECTAS, LO LAMENTAMOS");
                        Console.WriteLine("-------------------------------------------------------------");
                    }
                    break;
                }
                default:
                {
                    Console.WriteLine("\n-------------------------------------------------------------");
                    Console.WriteLine("\tESA OPCIÓN NO EXISTE");
                    Console.WriteLine("-------------------------------------------------------------");
                    break;
                }
            }
        } while (flag);

        Console.WriteLine("\n\tLAS SELECCIONES 2022 HAN FINALIZADO");
    }

    static Candidato[] IniciarCandidatos()
    {
        Candidato[] candidatos = new Candidato[NOCANDIDATOS];
        for (int i = 0; i < candidatos.Length; i++)
        {
            Candidato candidato = new Candidato(NombrarCandidato($"Ingrese el nombre del candidato {i + 1}: "));
            candidatos[i] = candidato;
        }
        return candidatos;
    }

    static void MostrarResultados(Candidato[] candidatos)
    {
        int totalVotos = candidatos.Sum(it => it.Votos);
        Console.WriteLine("\n-------------------------------------------------------------");
        Candidato posibleGanador = ObtenerGanador(candidatos);
        if (posibleGanador != null)
        {
            Console.WriteLine($"\tGANADOR: {posibleGanador.Nombre} CON {posibleGanador.Votos} VOTOS A FAVOR");
            Console.WriteLine("RESULTADOS:");
            foreach (Candidato candidato in candidatos)
                Console.WriteLine($"{candidato.Nombre} CON {candidato.Votos} VOTOS, REPRESENTANDO EL {candidato.Votos * 100 / totalVotos}%");
        }
        else
        {
            Console.WriteLine("\tSE CAYÓ EL SISTEMA");
            Console.WriteLine("\tHUBÓ UN EMPATE EN LAS SECCIONES");
        }
        Console.WriteLine("-------------------------------------------------------------");
    }

    static Candidato ObtenerGanador(Candidato[] candidatos)
    {
        candidatos = candidatos.OrderByDescending(it => it.Votos).ToArray();
        Candidato posibleGanador = candidatos[0];
        for (int i = 1; i < candidatos.Length; i++)
        {
            if (candidatos[0].Votos == candidatos[i].Votos)
            {
                posibleGanador = null;
                break;
            }
        }
        return posibleGanador;
    }

    static bool CerrarElecciones()
    {
        bool flag = false;
        int intentos = 3;
        string? contrasena;
        for (int i = 0; i < intentos; i++)
        {
            Console.Write("Ingrese la contraseña: ");
            contrasena = Console.ReadLine();
            if (contrasena != null && contrasena.Equals(CONTRASENA))
            {
                flag = true;
                break;
            }
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine($"\tCONTRASEÑA INCORRECTA LLEVAS {i + 1} INTENTOS DE {intentos}");
            Console.WriteLine("-------------------------------------------------------------");
        }
        return flag;
    }

    static string NombrarCandidato(string sms)
    {
        string? nombre;
        bool flag = false;
        Regex rx = new Regex("[a-zA-Z ñÁÉÍÓÚáéíúó]");
        do
        {
            Console.Write(sms);
            nombre = Console.ReadLine();
            MatchCollection matches = rx.Matches(nombre);
            if (matches.Count > 0) flag = true;
            else Console.WriteLine("\t NOMBRE NO VÁLIDO");
        } while (!flag);
        return nombre;
    }

    static int ObtenerNumero(string sms, int arribade = 0)
    {
        bool flag = false;
        int num = 0;
        do
        {
            try
            {
                Console.Write(sms);
                num = Convert.ToInt32(Console.ReadLine());
                if (num > arribade) flag = true;
                else Console.WriteLine($"\tDEBE SER MAYOR A {arribade}");
            }
            catch (Exception)
            {
                Console.WriteLine("\tENTRADA NO VÁLIDA");
            }
        } while (!flag);
        return num;
    }
}