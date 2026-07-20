using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== GIT AVANZADO Y GESTIÓN DE MEMORIA ===\n");
        
        Console.WriteLine("--- TIPOS DE VALOR Y REFERENCIA ---");
        
        int a = 10;
        int b = a;
        b = 20;
        Console.WriteLine($"Tipo de valor - a: {a}, b: {b}");
        
        Persona p1 = new Persona("Gael", 22);
        Persona p2 = p1;
        p2.Nombre = "Alberto";
        Console.WriteLine($"Tipo de referencia - p1: {p1.Nombre}, p2: {p2.Nombre}");
        
        Console.WriteLine("\n--- PASO POR VALOR Y REFERENCIA ---");
        
        int numero = 5;
        Console.WriteLine($"Antes de DuplicarValor: {numero}");
        DuplicarValor(numero);
        Console.WriteLine($"Después de DuplicarValor: {numero}");
        
        Console.WriteLine($"Antes de DuplicarReferencia: {numero}");
        DuplicarReferencia(ref numero);
        Console.WriteLine($"Después de DuplicarReferencia: {numero}");
        
        Console.WriteLine("\n--- STACK VS HEAP ---");
        Console.WriteLine("Stack: Tipos de valor (int, double, structs)");
        Console.WriteLine("Heap: Tipos de referencia (class, arrays, strings)");
        
        string saludo = "Hola";
        string saludoModificado = saludo + " Mundo";
        Console.WriteLine($"\nString original: {saludo}");
        Console.WriteLine($"String modificado: {saludoModificado}");
        Console.WriteLine("(Los strings son inmutables, se crea una nueva instancia en Heap)");
        
        Console.WriteLine("\n¡Programa finalizado!");
    }
    
    static void DuplicarValor(int x)
    {
        x = x * 2;
        Console.WriteLine($"Dentro de DuplicarValor: {x}");
    }
    
    static void DuplicarReferencia(ref int x)
    {
        x = x * 2;
        Console.WriteLine($"Dentro de DuplicarReferencia: {x}");
    }
}

class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    
    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }
}