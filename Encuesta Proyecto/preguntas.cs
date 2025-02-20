using System;
using System.Collections.Generic;
using System.IO;

class Preguntas
{
    private static string archivoPreguntas = "Preguntas.txt";

    public static void AgregarPregunta(string pregunta, List<string> opciones)
    {
        using (StreamWriter sw = new StreamWriter(archivoPreguntas, true))
        {
            sw.WriteLine(pregunta);
            foreach (string opcion in opciones)
            {
                sw.WriteLine(opcion);
            }
            sw.WriteLine("<->");
        }
    }

    public static List<Pregunta> CargarPreguntas()
    {
        List<Pregunta> listaPreguntas = new List<Pregunta>();

        if (File.Exists(archivoPreguntas))
        {
            string[] lineas = File.ReadAllLines(archivoPreguntas);
            List<string> opciones = new List<string>();
            string preguntaTexto = "";

            foreach (string linea in lineas)
            {
                if (linea == "<->")
                {
                    listaPreguntas.Add(new Pregunta(preguntaTexto, new List<string>(opciones)));
                    opciones.Clear();
                }
                else if (opciones.Count == 0)
                {
                    preguntaTexto = linea;
                }
                else
                {
                    opciones.Add(linea);
                }
            }
        }

        return listaPreguntas;
    }
}

public class Pregunta
{
    public string Texto { get; }
    public List<string> Opciones { get; }

    public Pregunta(string texto, List<string> opciones)
    {
        Texto = texto;
        Opciones = opciones;
    }
}
