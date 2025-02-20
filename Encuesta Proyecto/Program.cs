using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static string archivoPreguntas = "Preguntas.txt";
    private static string archivoRespuestas = "RespuestasCorrectas.txt";

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Encuesta");
            Console.WriteLine("2. Agregar pregunta");
            Console.WriteLine("3. Elegir respuestas");
            Console.WriteLine("4. Terminar");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("¡Error! Debes escribir un número.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RealizarEncuesta();
                    return;
                case 2:
                    AgregarPregunta();
                    break;
                case 3:
                    ElegirRespuestas();
                    break;
                case 4:
                    Console.WriteLine("Terminando...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 4);
    }

    static void RealizarEncuesta()
    {
        List<(string Pregunta, List<string> Opciones, char Correcta)> preguntas = CargarPreguntas();

        if (preguntas.Count == 0)
        {
            Console.WriteLine("No hay preguntas guardadas. Por favor, agregue preguntas.");
            return;
        }

        Console.WriteLine("\n--- ENCUESTA ---");
        foreach (var (pregunta, opciones, correcta) in preguntas)
        {
            Console.WriteLine($"\n{pregunta}");
            for (int i = 0; i < opciones.Count; i++)
            {
                Console.WriteLine($"{(char)('A' + i)}. {opciones[i]}");
            }

            Console.Write("Seleccione su respuesta (A, B, C, ...): ");
            char respuesta;
            while (true)
            {
                string input = Console.ReadLine().ToUpper();
                if (input.Length == 1 && input[0] >= 'A' && input[0] < 'A' + opciones.Count)
                {
                    respuesta = input[0];
                    break;
                }
                Console.Write("Opción inválida. Inténtalo de nuevo: ");
            }

            if (respuesta == correcta)
            {
                Console.WriteLine("¡Excelente, es la correcta!");
            }
            else
            {
                Console.WriteLine("Respuesta incorrecta.");
            }
        }
    }

    static void AgregarPregunta()
    {
        Console.Write("Escribe la nueva pregunta: ");
        string pregunta = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(archivoPreguntas, true))
        {
            sw.WriteLine(pregunta);
        }

        Console.WriteLine("Pregunta agregada con éxito.");
    }

    static void ElegirRespuestas()
    {
        List<string> preguntas = new List<string>();
        if (File.Exists(archivoPreguntas))
        {
            preguntas = new List<string>(File.ReadAllLines(archivoPreguntas));
        }

        if (preguntas.Count == 0)
        {
            Console.WriteLine("No hay preguntas guardadas. Por favor, agregue preguntas.");
            return;
        }

        Console.WriteLine("\n--- ELEGIR RESPUESTAS ---");
        for (int i = 0; i < preguntas.Count; i++)
        {
            Console.WriteLine($"Pregunta {i + 1}: {preguntas[i]}");
        }

        Console.Write("Elige el número de la pregunta: ");
        int numPregunta;
        while (!int.TryParse(Console.ReadLine(), out numPregunta) || numPregunta < 1 || numPregunta > preguntas.Count)
        {
            Console.Write("Número de pregunta inválido. Inténtalo de nuevo: ");
        }

        Console.WriteLine("Escribe las opciones (escribe 'fin' para terminar):");
        List<string> opciones = new List<string>();
        string opcion;
        while (true)
        {
            Console.Write($"Opción {(char)('A' + opciones.Count)}: ");
            opcion = Console.ReadLine();
            if (opcion.ToLower() == "fin")
            {
                break;
            }
            opciones.Add(opcion);
        }

        Console.Write("Elige la opción correcta (A, B, C, ...): ");
        char correcta;
        while (true)
        {
            string input = Console.ReadLine().ToUpper();
            if (input.Length == 1 && input[0] >= 'A' && input[0] < 'A' + opciones.Count)
            {
                correcta = input[0];
                break;
            }
            Console.Write("Opción inválida. Inténtalo de nuevo: ");
        }

        using (StreamWriter sw = new StreamWriter(archivoRespuestas, true))
        {
            sw.WriteLine($"{numPregunta - 1}:{correcta}");
        }

        Console.WriteLine("Respuesta correcta guardada con éxito.");
    }

    static List<(string Pregunta, List<string> Opciones, char Correcta)> CargarPreguntas()
    {
        List<(string, List<string>, char)> preguntas = new List<(string, List<string>, char)>();

        if (!File.Exists(archivoPreguntas) || !File.Exists(archivoRespuestas))
        {
            return preguntas;
        }

        List<string> lineasPreguntas = new List<string>(File.ReadAllLines(archivoPreguntas));
        Dictionary<int, char> respuestas = new Dictionary<int, char>();

        string[] lineasRespuestas = File.ReadAllLines(archivoRespuestas);
        foreach (string linea in lineasRespuestas)
        {
            string[] partes = linea.Split(':');
            if (partes.Length == 2 && int.TryParse(partes[0], out int numPregunta) && partes[1].Length == 1)
            {
                respuestas[numPregunta] = partes[1][0];
            }
        }

        for (int i = 0; i < lineasPreguntas.Count; i++)
        {
            if (respuestas.ContainsKey(i))
            {
                preguntas.Add((lineasPreguntas[i], new List<string>(), respuestas[i]));
            }
        }

        return preguntas;
    }
}