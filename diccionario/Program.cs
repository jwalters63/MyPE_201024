using System;
using System.Collections.Generic;

class Programa
{
    static void Main()
    {
        var traducciones = crearDiccionario();

        // Buscar traducciones
        string palabraBuscar = PedirPalabra("Ingresa una palabra en inglés para traducir:");
        if (string.IsNullOrWhiteSpace(palabraBuscar))
        {
            Console.WriteLine("La palabra a buscar no puede estar vacía.");
            return;
        }

        traducir(traducciones, palabraBuscar);
    }

    static List<(string Ingles, string Español)> crearDiccionario()
    {
        var diccionario = new List<(string, string)>();
        int contador = 0; // Contador para limitar a 5 traducciones

        while (contador < 5)
        {
            string ingles = PedirPalabra("Ingresa una palabra en inglés (o presiona Enter para terminar):");
            if (string.IsNullOrWhiteSpace(ingles)) break;

            string español = PedirPalabra("Ingresa la traducción en español:");
            if (string.IsNullOrWhiteSpace(español))
            {
                Console.WriteLine("La traducción no puede estar vacía. Inténtalo de nuevo.");
                continue;
            }

            diccionario.Add((ingles, español)); // Agregar la tupla al diccionario
            contador++; // Incrementar el contador
        }

        return diccionario;
    }

    static void traducir(List<(string Ingles, string Español)> diccionario, string palabraBuscar)
    {
        foreach (var traduccion in diccionario)
        {
            if (traduccion.Ingles.Equals(palabraBuscar, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"La traducción de '{palabraBuscar}' es '{traduccion.Español}'.");
                return;
            }
        }

        Console.WriteLine($"No se encontró la traducción para '{palabraBuscar}'.");
    }

    static string PedirPalabra(string mensaje)
    {
        Console.WriteLine(mensaje);
        return Console.ReadLine();
    }
}