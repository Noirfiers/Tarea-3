using System;

class Encuesta
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
            Console.WriteLine("3. Responder preguntas");
            Console.WriteLine("4. Salir");

            
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
                    ResponderPregunta();
                    break;
                case 4:
                    Console.WriteLine("Bye");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 4);
    }

    static void AgregarPregunta()
    {
        
        if (contador >= 20)
        {
            Console.WriteLine("¡Demasiadas preguntas, calmate!");
            return;
        }

        Console.Write("Escribe tu pregunta: ");
        preguntas[contador] = Console.ReadLine();
        contador++;
        Console.WriteLine("¡Pregunta agregada!");
    }

    static void ResponderPregunta()
    {
       
        if (contador == 0)
        {
            Console.WriteLine("No hay preguntas para responder.");
            return;
        }

        
        Console.WriteLine("¿Qué pregunta deseas responder? (1-20): ");
        int preguntaSeleccionada;
        if (int.TryParse(Console.ReadLine(), out preguntaSeleccionada) && preguntaSeleccionada >= 1 && preguntaSeleccionada <= contador)
        {
            Console.WriteLine($"Pregunta: {preguntas[preguntaSeleccionada - 1]}");
            Console.Write("Escribe tu respuesta: ");
            respuestas[preguntaSeleccionada - 1] = Console.ReadLine();
            Console.WriteLine("¡Respuesta registrada!");
        }
        else
        {
            Console.WriteLine("Número de pregunta inválido.");
        }
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

        
        Console.WriteLine("\n-> RESPUESTAS <-");
        for (int i = 0; i < contador; i++)
        {
            if (!string.IsNullOrEmpty(respuestas[i]))
            {
                Console.WriteLine($"{i + 1}. Respuesta: {respuestas[i]}");
            }
        }
    }
}
