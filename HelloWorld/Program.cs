/*
  - Saldaña Espinoza Hector
  - Desarrollo web integral
  - 9B
*/

namespace HelloWorld
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            // Init();
            // TiendaProductos();
            // Minusculas();
            // Pizzas();
            // EmpresaBonos();
            Figuras();
        }

        static void Figuras()
        {
            double perimetro = 0, area = 0;
            bool salirGeneral = false;
            do
            {
                Console.WriteLine("\n\tMENÚ");
                Console.WriteLine("1. Círculo");
                Console.WriteLine("2. Hexágono");
                Console.WriteLine("3. Rombo");
                Console.WriteLine("4. Salir");
                int opc = ObtenerNumero("Escoge una opción: ");
                switch (opc)
                {
                    case 1:
                    {
                        double radio;
                        radio = ObtenerNumeroDecimal("Dame el radio: ");
                        perimetro = 2 * Math.PI * radio;
                        area = Math.PI * Math.Pow(radio, 2);
                        break;
                    }
                    case 2:
                    {
                        double lado, apotema;
                        lado = ObtenerNumeroDecimal("Dame la longitud del lado: ");
                        apotema = ObtenerNumeroDecimal("Dame su apotema: ");
                        perimetro = lado * 6;
                        area = (perimetro * apotema) / 2;
                        break;
                    }
                    case 3:
                    {
                        double diagonalMayor, diagonalMenor;
                        diagonalMenor = ObtenerNumeroDecimal("Dame la diagonal menor: ");
                        diagonalMayor = ObtenerNumeroDecimal("Dame la diagonal mayor: ");
                        perimetro = 2 * (Math.Sqrt((Math.Pow(diagonalMayor, 2) + Math.Pow(diagonalMenor, 2))));
                        area = (diagonalMayor * diagonalMenor) / 2;
                        break;
                    }
                    case 4:
                    {
                        salirGeneral = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("\nESA OPCIÓN NO EXISTE");
                        break;
                    }
                }

                if (perimetro != 0 && area != 0 && opc != 4)
                {
                    Console.WriteLine("\n\t RESUMEN");
                    Console.WriteLine($"El perímetro es: {perimetro} unidades");
                    Console.WriteLine($"El área es: {area} unidades cuadradas");
                }
            } while (!salirGeneral);
        }

        static void EmpresaBonos()
        {
            const float salarioMinimo = 172.87F;
            string? departamento;
            int antiguedad, bono = 0;
            Console.Write("Ingresa tu departamento: ");
            departamento = Console.ReadLine();
            antiguedad = ObtenerNumero("Ingresa tu antiguedad (meses): ");
            departamento = departamento.ToUpper();
            switch (departamento)
            {
                case "A":
                {
                    if (antiguedad < 23) bono = 5;
                    else bono = 8;
                    break;
                }
                case "B":
                {
                    if (antiguedad < 35) bono = 9;
                    else bono = 12;
                    break;
                }
                case "C":
                {
                    if (antiguedad < 59) bono = 14;
                    else bono = 17;
                    break;
                }
                default:
                {
                    Console.WriteLine("EL DEPARTAMENTO NO EXISTE :(");
                    break;
                }
            }

            if (bono != 0)
            {
                float pagoPorHijo = 0;
                int hijos;
                hijos = ObtenerNumero("¿Cuántos hijos tienes?: ", -1);
                pagoPorHijo = hijos * 150f;
                Console.WriteLine("\n\t RESUMEN");
                Console.WriteLine($"Departamento seleccionado: {departamento}");
                Console.WriteLine($"Meses de antiguedad: {antiguedad}");
                Console.WriteLine($"Número de hijos: {hijos}");
                Console.WriteLine($"Pago por hijos: ${pagoPorHijo}");
                Console.WriteLine($"Bono obtenido de: {bono} salarios mínimos");
                Console.WriteLine($"En tèrminos de dinero son: ${bono * salarioMinimo}");
            }
            else Console.WriteLine("NO OBTUVISTE NINGUN BONO :(");
        }

        static void Pizzas()
        {
            float[] precios = { 150, 155, 145, 168, 159 };
            string[] pizzas = { "Hawaiana", "Pepperoni", "Quesos", "Margarita", "Salami" };
            float total = 0, pagoTarjeta = 0, totalGeneral, pagoEntrega = 0;
            string pizzasSelecionadas = "";
            int i;
            bool salirGeneral = false;
            do
            {
                Console.WriteLine("\tMENÚ");
                for (i = 0; i < pizzas.Length; i++) Console.WriteLine($"{i + 1}.- {pizzas[i]} - $ {precios[i]}");
                Console.WriteLine($"{i + 1}.- Salir y obtener resumen");
                int opc = ObtenerNumero("Escoge una opción: ");
                switch (opc)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    {
                        total += precios[opc - 1];
                        pizzasSelecionadas += $"1 x {pizzas[opc - 1]} ${precios[opc - 1]}\n";
                        Console.WriteLine($"\n\tPIZZA AGREGADA CORRECTAMENTE\n");
                        break;
                    }
                    case 6:
                    {
                        salirGeneral = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("\nESA OPCIÓN NO EXISTE");
                        break;
                    }
                }
            } while (!salirGeneral);

            if (total > 0)
            {
                string? confirmacion;
                Console.Write("¿Pagará con tarjeta? (Sí = Escribe, No = Enter): ");
                confirmacion = Console.ReadLine();
                if (confirmacion.Length > 0) pagoTarjeta = total * 0.03f;
                Console.Write("¿Desea servicio a domicilio? (Sí = Escribe, No = Enter): ");
                confirmacion = Console.ReadLine();
                if (confirmacion.Length > 0) pagoEntrega = 45f;
                totalGeneral = total + pagoTarjeta + pagoEntrega;
                Console.WriteLine("\n\t RESUMEN");
                Console.WriteLine($"{pizzasSelecionadas}");
                Console.WriteLine($"--------------------------------");
                Console.WriteLine($"Total (Sin pago tarjeta): ${total}");
                Console.WriteLine($"Costo de pago con tarjeta (3%): ${pagoTarjeta}");
                Console.WriteLine($"Costo de entrega: ${pagoEntrega}");
                Console.WriteLine($"Total final (+tarjeta+entrega): ${totalGeneral}");
            }
            else Console.WriteLine("NO REALIZASTE NINGUNA COMPRA :(");
        }

        static void Minusculas()
        {
            Console.Write("Escribe un texto: ");
            string? text = Console.ReadLine();
            if (text.Length > 10) text = text.ToLower();
            Console.WriteLine($"Tu texto fue: {text}");
        }

        static void TiendaProductos()
        {
            const float PRECIO = 15.9f;
            int productos = ObtenerNumero("Ingrese los productos comprados: ");
            int promociones = productos / 5;
            int productosNoDescuento = productos % 5;
            float precioProductoNoDescuento = productosNoDescuento * PRECIO;
            float precioSinDescuento = promociones * 5 * PRECIO + precioProductoNoDescuento;
            float precioDescuentoAplicado = promociones * 5 * PRECIO * 0.10f;
            float precioProductoDescuento = (promociones * 5 * PRECIO) - precioDescuentoAplicado;
            float precioFinal = precioProductoDescuento + precioProductoNoDescuento;
            Console.WriteLine("\n\t\t RESUMEN");
            Console.WriteLine($"\tTotal de promociones: {promociones}");
            Console.WriteLine($"\tLápices regalados: {promociones}");
            Console.WriteLine($"\tProductos sin descuento: {productosNoDescuento}");
            Console.WriteLine($"\n\tTotal sin descuento: ${precioSinDescuento}");
            Console.WriteLine($"\tDescuento aplicado: ${precioDescuentoAplicado}");
            Console.WriteLine($"\tTotal final: ${precioFinal}");
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

        static double ObtenerNumeroDecimal(string sms, double arribade = 0.0)
        {
            bool flag = false;
            double num = 0;
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

        static void Init()
        {
            Console.Write("Hello ");
            Console.WriteLine("World!");
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();
            Console.Write("Good day, ");
            Console.Write(name);
            Console.Write("!");
            var currentDay = DateTime.Now;
            Console.WriteLine($"{Environment.NewLine} nueva línea");
            Console.WriteLine($"Hello {name}");
            Console.WriteLine($"Día de hoy: {currentDay:d} ");
            Console.WriteLine($"Hora de hoy: {currentDay:t}");
            Console.WriteLine($"Día de hoy en otro formato: {currentDay:m}");
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num + 10);
        }
    }
}