using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Preguntas
{
    static string[] preguntas = new string[20];
    static string[] respuestas = new string[20];
    static int contador = 0; 
    static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine(" MENU :) ");
            Console.WriteLine("1. Agregar pregunta");
            Console.WriteLine("2. Ver todas las preguntas");
            Console.WriteLine("3. Salir");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("¡Error! Debes escribir un número.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    AgregarPregunta();
                    break;
                case 2:
                    VerPreguntas();
                    break;
                case 3:
                    Console.WriteLine(" Bye ");
                    break;
                default:
                    Console.WriteLine("Opción no válida ");
                    break;
            }
        } while (opcion != 3);
    }

    static void AgregarPregunta()
    {
        if (contador >= 20)
        {
            Console.WriteLine(" Muchas pregunta calmate! ");
            return;
        }

        Console.Write("Escribe tu pregunta: ");
        preguntas[contador] = Console.ReadLine();
        contador++;
        Console.WriteLine("¡Pregunta agregada!");
    }
    static void ResponderPregunta()
    {
        Console.WriteLine(" Pregunta que queras responder? (1-20) ");
    }

    static void VerPreguntas()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay preguntas aún.");
            return;
        }

        Console.WriteLine("-> LISTA DE PREGUNTAS <-");
        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine($"{i + 1}. {preguntas[i]}");
        }
    }
}
