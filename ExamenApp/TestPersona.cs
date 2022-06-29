using System.Text.RegularExpressions;

namespace ExamenApp;

public class TestPersona
{
    public static Persona persona;
    static void Main(string[] args)
    {


        bool flag1 = true;
        bool flag2 = true;
        int opc1, opc2;
        InitialRun();
        do
        {
            Console.WriteLine("\n############################ MENÚ #################################");
            Console.WriteLine("1. MOSTRAR LOS DATOS\n2. CAMBIAR DATOS\n3. SALIR ");
            opc1 = PutNumber("INGRESE UNA OPCIÓN: ");
            switch (opc1)
            {
                case 1:
                    {
                        Console.WriteLine("-------------------------------------------------------------");
                        persona.GetAllData();
                        Console.WriteLine("-------------------------------------------------------------");
                        break;
                    }
                case 2:
                    {
                        do
                        {
                            bool flag3 = false;
                            Console.WriteLine("\n############################ SUBMENÚ #################################");
                            Console.WriteLine("1. MODIFICAR NOMBRE\n2. MODIFICAR EDAD\n3. MODIFICAR ESTATURA\n4. MODIFICAR SEXO\n5. MODIFICAR ESTADO CIVIL\n6. REGRESAR AL MENÚ");
                            opc2 = PutNumber("INGRESE UNA OPCIÓN: ");
                            switch (opc2)
                            {
                                case 1:
                                    {
                                        string _nombre = PutName("INGRESE EL NUEVO NOMBRE DE LA PERSONA: ");
                                        if (confirmData())
                                        {
                                            persona.SetNombre(_nombre);
                                            flag3 = true;
                                        };
                                        break;
                                    }
                                case 2:
                                    {
                                        int _edad = PutNumber("INGRESE LA NUEVA EDAD DE LA PERSONA: ");
                                        if (confirmData())
                                        {
                                            persona.SetEdad(_edad);
                                            flag3 = true;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        float _estatura = PutDecimal("INGRESE LA NUEVA ESTATURA DE LA PERSONA: ");
                                        if (confirmData())
                                        {
                                            persona.SetEstatura(_estatura);
                                            flag3 = true;
                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        char _sexo = PutGender("INGRESE EL NUEVO SEXO DE LA PERSONA (H O M): ");
                                        if (confirmData())
                                        {
                                            persona.SetSexo(_sexo);
                                            flag3 = true;
                                        }
                                        break;
                                    }
                                case 5:
                                    {
                                        bool _estadocivil = PutMarrital("INGRESE EL NUEVO ESTADO CIVIL DE LA PERSONA (1. Casado o 2. Soltero): ");
                                        if (confirmData())
                                        {
                                            persona.SetEstadoCivil(_estadocivil);
                                            flag3 = true;
                                        }
                                        break;
                                    }
                                case 6:
                                    {
                                        flag2 = false;
                                        Console.WriteLine("\n-------------------------------------------------------------");
                                        Console.WriteLine("\tREGRESANDO.....");
                                        Console.WriteLine("-------------------------------------------------------------");
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
                            if (flag3)
                            {
                                flag2 = true;
                                Console.WriteLine("\n-------------------------------------------------------------");
                                Console.WriteLine("\tDATO GUARDADO EXITOSAMENTE");
                                Console.WriteLine("-------------------------------------------------------------");
                            }
                        } while (flag2);
                        break;
                    }
                case 3:
                    {
                        flag1 = false;
                        Console.WriteLine("\n-------------------------------------------------------------");
                        Console.WriteLine("\tSALIENDO.....");
                        Console.WriteLine("-------------------------------------------------------------");
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

        } while (flag1);
    }

    public static void InitialRun()
    {
        persona = new Persona(
            PutName("INGRESE EL NOMBRE DE LA PERSONA: "),
            PutNumber("INGRESE LA EDAD DE LA PERSONA: "),
            PutDecimal("INGRESE LA ESTATURA DE LA PERSONA: "),
            PutGender("INGRESE EL SEXO DE LA PERSONA (H O M): "),
            PutMarrital("INGRESE EL ESTADO CIVIL DE LA PERSONA (1. Casado o 2. Soltero): ")
            );
    }

    public static bool confirmData()
    {
        bool confirm = false;
        bool flag = true;
        string? tmp;
        do
        {
            Console.Write("¿ESTÁS SEGURO DE REALIZAR EL CAMBIO? (1.- Sí o 2. No): ");
            tmp = Console.ReadLine();
            switch (tmp)
            {
                case "1":
                    {
                        confirm = true;
                        flag = false;
                        break;
                    }
                case "2":
                    {
                        confirm = false;
                        flag = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\tENTRADA NO VÁLIDA, SOLÓ 1 O 2");
                        break;
                    }
            }

        } while (flag);
        return confirm;
    }

    public static bool PutMarrital(string sms)
    {
        bool casado = false;
        bool flag = true;
        string? tmp;
        do
        {
            Console.Write(sms);
            tmp = Console.ReadLine();
            switch (tmp)
            {
                case "1":
                    {
                        casado = true;
                        flag = false;
                        break;
                    }
                case "2":
                    {
                        casado = false;
                        flag = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\tENTRADA NO VÁLIDA, SOLÓ 1 O 2");
                        break;
                    }
            }

        } while (flag);
        return casado;
    }


    static float PutDecimal(string sms, float arribade = 0.0F)
    {
        bool flag = false;
        float num = 0.0F;
        do
        {
            try
            {
                Console.Write(sms);
                num = Convert.ToSingle(Console.ReadLine());
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

    static int PutNumber(string sms, int arribade = 0)
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
                Console.WriteLine("\tENTRADA NO VÁLIDA, SOLÓ DÍGITOS");
            }
        } while (!flag);

        return num;
    }

    static string PutName(string sms)
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

    public static char PutGender(string sms)
    {
        string genero;
        bool flag = true;
        do
        {
            try
            {
                Console.Write(sms);
                genero = Console.ReadLine();
                switch (genero)
                {
                    case "H":
                    case "h":
                    case "M":
                    case "m":
                        {
                            flag = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\tENTRADA NO VÁLIDA, SOLÓ H O M");
                            break;
                        }
                }
            }
            catch (Exception)
            {
                genero = null;
                Console.WriteLine("\tENTRADA NO VÁLIDA, SOLÓ CARACTER");
            }

        } while (flag);
        return Char.Parse(genero);
    }
}