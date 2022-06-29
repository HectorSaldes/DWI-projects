using System.Text.RegularExpressions;

namespace HelloWorld.NewDirectory1;

public class TestCandidatos
{
    private const string CONTRASENA = "DM";
    private const int NOCANDIDATOS = 3;

    /*static void Main()
    {
        InicioElecciones();
    }*/

    static void InicioElecciones()
    {
        bool flag = true;
        Candidato[] candidatos = IniciarCandidatos();
        do
        {
            int i, opc;
            Console.WriteLine("\n\tMENÚ SELECCIONES 2022 EMILIANO ZAPATA POR LA JUSTICIA DE LA BENITO");
            for (i = 0; i < candidatos.Length; i++)
                Console.WriteLine($"{i + 1}. Votar por el candidato: {candidatos[i].Nombre}");
            Console.WriteLine($"{i + 1}. Cerrar casillas");
            opc = ObtenerNumero("Elija una opción: ");
            switch (opc)
            {
                case > 0 and < 4:
                {
                    candidatos[opc - 1].AumentarVoto();
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
                    else Console.WriteLine("\n\tESAS NO FUERON LAS CONTRASEÑAS CORRECTAS, LO LAMENTAMOS");
                    break;
                }
                default:
                {
                    Console.WriteLine("\n\tESA OPCIÓN NO EXISTE");
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
        int totalVotos = 0;
        HashSet<int> reecuento = new HashSet<int>();
        foreach (Candidato candidato in candidatos)
        {
            totalVotos += candidato.Votos;
            reecuento.Add(candidato.Votos);
        }
        Console.WriteLine("\n-------------------------------------------------------------");
        if (reecuento.Count == NOCANDIDATOS)
        {
            
            foreach (Candidato candidato in candidatos)
            {
                // Console.WriteLine($"Canditato: {candidato.Nombre}, ontv")
            }
        }
        else
        {
            Console.WriteLine("\tSE CAYÓ EL SISTEMA");
            Console.WriteLine("\tHUBÓ UN EMPATE EN LAS SECCIONES");
        }
        Console.WriteLine("-------------------------------------------------------------");
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

            Console.WriteLine($"\tCONTRASEÑA INCORRECDMDMTA LLEVAS {i + 1} INTENTOS DE {intentos}");
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