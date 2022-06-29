namespace Banco;

/*
  - Saldaña Espinoza Hector
  - Desarrollo web integral
  - 9B
*/
public class CuentaBancaria
{
    public string Titular { get; set; }
    public double Saldo { get; set; }
    public string Cuenta { get; set; }
    public string Nip { get; set; }

    public CuentaBancaria(string titular, double saldo, string nip)
    {
        Titular = titular;
        Saldo = saldo;
        Nip = nip;
        Cuenta = GenerarNip();
    }

    private string GenerarNip()
    {
        return $"{new Random().Next(10000000, 99999999)}";
    }

    public bool Depositar(double monto)
    {
        bool flag = false;
        try
        {
            Saldo += monto;
            flag = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return flag;
    }

    public bool Retirar(double monto)
    {
        bool flag = false;
        try
        {
            if (monto <= Saldo)
            {
                Saldo -= monto;
                flag = true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return flag;
    }


    public string Consultar()
    {
        return $"EL CLIENTE: {Titular}, TIENE UN MONTO DE: ${Saldo} EN SU CUENTA";
    }
}