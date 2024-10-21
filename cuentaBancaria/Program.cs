using System;
using System.Collections.Generic;

namespace cuentaBancaria
{
    class Programa
    {
        static void Main(string[] args)
        {
            decimal saldo = 0;
            List<decimal> transacciones = new List<decimal>();

            while (true)
            {
                Console.WriteLine("Menú de opciones:");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine($"Saldo actual: ${saldo:F2}");
                        break;
                    case "2":
                        Console.Write("Ingrese la cantidad a depositar: ");
                        decimal deposito = Convert.ToDecimal(Console.ReadLine());
                        saldo += deposito;
                        transacciones.Add(deposito);
                        Console.WriteLine($"Has depositado ${deposito:F2}. Saldo actual: ${saldo:F2}");
                        break;
                    case "3":
                        Console.Write("Ingrese la cantidad a retirar: ");
                        decimal retiro = Convert.ToDecimal(Console.ReadLine());
                        if (retiro <= saldo)
                        {
                            saldo -= retiro;
                            transacciones.Add(-retiro);
                            Console.WriteLine($"Has retirado ${retiro:F2}. Saldo actual: ${saldo:F2}");
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Gracias por usar el programa. ¡Adiós!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}