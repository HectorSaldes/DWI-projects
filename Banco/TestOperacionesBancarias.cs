using System.Text.RegularExpressions;

namespace Banco;

/*
  - Saldaña Espinoza Hector
  - Desarrollo web integral
  - 9B
*/
public class TestOperacionesBancarias
{
    private const int NOCUENTAS = 2;
    private static CuentaBancaria[] cuentas = new CuentaBancaria[NOCUENTAS];
    private static CuentaBancaria? cuentaseleccionada;

    static void Main(string[] args)
    {
        bool flag1 = true;
        string[] submenu =
        {
            "CONSULTAR SALDO", "DEPOSITAR EFECTIVO", "RETIRAR EFECTIVO", "TRANSFERIR ENTRE CUENTAS", "CAMBIAR NIP",
            "CERRAR SESIÓN"
        };
        IniciarCuentas();
        do
        {
            bool flag2;
            int i, opc1, opc2;
            Console.WriteLine("\n############################ MENÚ #################################");
            for (i = 0; i < cuentas.Length; i++) Console.WriteLine($"{i + 1}. NÚMERO DE CUENTA: {cuentas[i].Cuenta}");
            Console.WriteLine($"{i + 1}. SALIR DEL CAJERO");
            opc1 = ObtenerNumero("SELECCIONE UNA OPCIÓN: ");
            switch (opc1)
            {
                case > 0 and <= NOCUENTAS:
                {
                    cuentaseleccionada = cuentas[opc1 - 1];
                    flag2 = ValidarNip();
                    while (flag2)
                    {
                        Console.WriteLine("\n************************** SUBMENÚ ***********************************");
                        Console.WriteLine($"\tHOLA, {cuentaseleccionada.Titular}");
                        for (int j = 0; j < submenu.Length; j++) Console.WriteLine($"{j + 1}. {submenu[j]}");
                        opc2 = ObtenerNumero("SELECCIONE UNA OPCIÓN: ");
                        Console.WriteLine("\n-------------------------------------------------------------");

                        switch (opc2)
                        {
                            case 1:
                            {
                                Console.WriteLine(cuentaseleccionada.Consultar());
                                break;
                            }
                            case 2:
                            {
                                double monto = ObtenerNumeroDecimal("INGRESE LA CANTIDAD A DEPOSITAR: $");
                                if (cuentaseleccionada.Depositar(monto)) Console.WriteLine("\n\tDEPOSITO EXITOSO");
                                else Console.WriteLine("\n\tOCURRIÓ UN ERROR CON EL DEPOSITO");
                                break;
                            }
                            case 3:
                            {
                                double monto = ObtenerNumeroDecimal("INGRESE LA CANTIDAD A RETIRAR: $");
                                if (cuentaseleccionada.Retirar(monto)) Console.WriteLine("\n\tRETIRO EXITOSO");
                                else Console.WriteLine("\n\tOCURRIÓ UN ERROR CON EL RETIRO, SALDO INSUFICIENTE");
                                break;
                            }
                            case 4:
                            {
                                Transferir();
                                break;
                            }
                            case 5:
                            {
                                flag2 = CambiarNip();
                                break;
                            }
                            case 6:
                            {
                                flag2 = false;
                                Console.WriteLine("\tREGRESANDO.....");
                                break;
                            }
                            default:
                            {
                                Console.WriteLine("\tESA OPCIÓN NO EXISTE");
                                break;
                            }
                        }

                        Console.WriteLine("-------------------------------------------------------------");
                    }

                    break;
                }
                case NOCUENTAS + 1:
                {
                    flag1 = false;
                    Console.WriteLine("\n-------------------------------------------------------------");
                    Console.WriteLine("\tGRACIAS POR USAR TU BANCO PREFERIDO");
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


    static bool CambiarNip()
    {
        bool flag = true;
        string nip = ObtenerNip("INGRESE EL NUEVO NIP: ");
        string nipdos = ObtenerNip("INGRESE NUEVAMENTE EL NUEVO NIP: ");
        if (nip.Equals(nipdos))
        {
            cuentaseleccionada.Nip = nip;
            Console.WriteLine("\n\tEL NIP FUE CAMBIADO EXITOSAMENTE, INGRESE A SU CUENTA CON SU NUEVO NIP");
            flag = false;
        }
        else Console.WriteLine("\n\tLOS NIPS NO COINCIDIERON, INTENTE NUEVAMENTE");

        return flag;
    }

    static void Transferir()
    {
        string nocuenta = ObtenerNumeroCuenta("INGRESE EL NÚMERO DE CUENTA A ENVIAR: ");
        CuentaBancaria? envio = Array.Find(cuentas, c => c.Cuenta.Equals(nocuenta));
        if (envio != null)
        {
            double monto = ObtenerNumeroDecimal("INGRESE LA CANTIDAD A TRANSFERIR: $");
            if (cuentaseleccionada.Retirar(monto))
            {
                if (envio.Depositar(monto)) Console.WriteLine("\n\tTRANSFERENCIA EXITOSA");
                else Console.WriteLine("\n\tOCURRIÓ UN ERROR CON LA TRANSFERENCIA");
            }
            else Console.WriteLine("\n\tOCURRIÓ UN ERROR CON EL RETIRO, SALDO INSUFICIENTE");
        }
        else Console.WriteLine("\n\tNÚMERO DE CUENTA INEXISTENTE");
    }

    static bool ValidarNip()
    {
        bool flag = false;
        try
        {
            for (int i = 1; i <= 3; i++)
            {
                string nip = ObtenerNip("INGRESE EL NIP DE LA CUENTA: ");
                if (cuentaseleccionada.Nip.Equals(nip))
                {
                    flag = true;
                    break;
                }

                Console.WriteLine("\n-------------------------------------------------------------");
                Console.WriteLine("\tEL NIP NO FUE EL CORRECTO");
                Console.WriteLine($"\tLLEVAS {i} INTENTOS DE 3");
                Console.WriteLine("-------------------------------------------------------------");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return flag;
    }


    static string ObtenerNumeroCuenta(string sms)
    {
        string? nocuenta;
        bool flag = false;
        Regex rx = new Regex("[0-9]");
        do
        {
            Console.Write(sms);
            nocuenta = Console.ReadLine();
            MatchCollection matches = rx.Matches(nocuenta);
            if (matches.Count > 0 && matches.Count == 8) flag = true;
            else Console.WriteLine("\t NO. DE CUENTA NO VÁLIDO");
        } while (!flag);

        return nocuenta;
    }

    static void IniciarCuentas()
    {
        for (int i = 0; i < cuentas.Length; i++)
        {
            Console.WriteLine($"\tDATOS DEL TITULAR {i + 1}");
            cuentas[i] = new CuentaBancaria(
                NombrarTitular("INGRESE EL NOMBRE DEL TITULAR: "),
                ObtenerNumeroDecimal("INGRESE EL SALDO INICIAL: $"),
                ObtenerNip("INGRESE EL NIP DE LA CUENTA: ")
            );
        }
    }

    static string NombrarTitular(string sms)
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
                Console.WriteLine("\tENTRADA NO VÁLIDA, SOLÓ DÍGITOS");
            }
        } while (!flag);

        return num;
    }


    static string ObtenerNip(string sms, int arribade = 0)
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

        return $"{num}";
    }


    static double ObtenerNumeroDecimal(string sms, double arribade = 0.0)
    {
        bool flag = false;
        double num = 0.0;
        do
        {
            try
            {
                Console.Write(sms);
                num = Convert.ToDouble(Console.ReadLine());
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