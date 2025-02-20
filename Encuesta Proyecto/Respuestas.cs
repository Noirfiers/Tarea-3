using System;
using System.Collections.Generic;
using System.IO;

class Respuestas
{
    private static string archivoRespuestas = "Respuestas.txt";

    public static void GuardarRespuesta(int numPregunta, int opcionCorrecta)
    {
        using (StreamWriter sw = new StreamWriter(archivoRespuestas, true))
        {
            sw.WriteLine($"{numPregunta}:{opcionCorrecta}");
        }
    }

    public static Dictionary<int, int> CargarRespuestas()
    {
        Dictionary<int, int> respuestasCorrectas = new Dictionary<int, int>();

        if (File.Exists(archivoRespuestas))
        {
            string[] lineas = File.ReadAllLines(archivoRespuestas);
            foreach (string linea in lineas)
            {
                string[] partes = linea.Split(':');
                if (partes.Length == 2 && int.TryParse(partes[0], out int pregunta) && int.TryParse(partes[1], out int respuesta))
                {
                    respuestasCorrectas[pregunta] = respuesta;
                }
            }
        }

        return respuestasCorrectas;
    }
}
