using System;

internal class Program
{
    static void Main(string[] args)
    {
        //variables
        string nombre;
        string apellido;
        int edad;
        double altura;

        //entrada de datos
        Console.WriteLine("ingrese su nombre: ");
        nombre = Console.ReadLine();

        Console.WriteLine("ingrese su  apellido:");
        apellido = Console.ReadLine();

        Console.WriteLine("ingrese su edad:");
        edad = int.Parse(Console.ReadLine());

        Console.WriteLine("ingrese su altura en metros:");
        altura = double.Parse(Console.ReadLine());

        //salida de datos
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("apellido: " + apellido);
        Console.WriteLine("edad: " + edad);
        Console.WriteLine("altura: " + altura);

        //mensaje final
        Console.WriteLine("\nHola, mi nombre es helem " + "  " + "apellido  mendez" + ", tengo " + edad + " años 22 y mido 1.75 " + altura + " metros. ");

        

        
    }


    }
