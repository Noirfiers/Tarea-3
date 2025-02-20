using System;
using System.Collections.Generic;

class Encuesta
{
    public static Dictionary<int, int> RealizarEncuesta(List<Pregunta> preguntas)
    {
        Dictionary<int, int> respuestasUsuario = new Dictionary<int, int>();

        Console.WriteLine("\n--- ENCUESTA ---");
        for (int i = 0; i < preguntas.Count; i++)
        {
            Console.WriteLine($"\nPregunta {i + 1}: {preguntas[i].Texto}");
            List<string> opciones = preguntas[i].Opciones;
            for (int j = 0; j < opciones.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {opciones[j]}");
            }

            Console.Write("Tu respuesta es: ");
            int respuesta;
            while (!int.TryParse(Console.ReadLine(), out respuesta) || respuesta < 1 || respuesta > opciones.Count)
            {
                Console.Write("Opción inválida. Inténtalo de nuevo: ");
            }

            respuestasUsuario[i] = respuesta - 1;
        }

        return respuestasUsuario;
    }
}