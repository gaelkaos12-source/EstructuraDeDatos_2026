using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== GIT AVANZADO Y GESTIÓN DE MEMORIA ===\n");
        
        // Demostración de tipos de valor y referencia
        Console.WriteLine("--- TIPOS DE VALOR Y REFERENCIA ---");
        
        // Tipo de valor (struct)
        int a = 10;
        int b = a; // Copia el valor
        b = 20;
        Console.WriteLine($"Tipo de valor - a: {a}, b: {b}");
        
        // Tipo de referencia (class)
        Persona p1 = new Persona("Gael", 22);
        Persona p2 = p1; // Copia la referencia
        p2.Nombre = "Alberto";
        Console.WriteLine($"Tipo de referencia - p1: {p1.Nombre}, p2: {p2.Nombre}");
        
        // Demostración de paso por valor y referencia
        Console.WriteLine("\n--- PASO POR VALOR Y REFERENCIA ---");
        
        int numero = 5;
        Console.WriteLine($"Antes de DuplicarValor: {numero}");
        DuplicarValor(numero);
        Console.WriteLine($"Después de DuplicarValor: {numero}");
        
        Console.WriteLine($"Antes de DuplicarReferencia: {numero}");
        DuplicarReferencia(ref numero);
        Console.WriteLine($"Después de DuplicarReferencia: {numero}");
        
        // Demostración de memoria stack vs heap
        Console.WriteLine("\n--- STACK VS HEAP ---");
        Console.WriteLine("Stack: Tipos de valor (int, double, structs)");
        Console.WriteLine("Heap: Tipos de referencia (class, arrays, strings)");
        
        // Ejemplo de string (inmutable)
        string saludo = "Hola";
        string saludoModificado = saludo + " Mundo";
        Console.WriteLine($"\nString original: {saludo}");
        Console.WriteLine($"String modificado: {saludoModificado}");
        Console.WriteLine("(Los strings son inmutables, se crea una nueva instancia en Heap)");
        
        Console.WriteLine("\n¡Programa finalizado!");
    }
    
    // Paso por valor (copia el valor)
    static void DuplicarValor(int x)
    {
        x = x * 2;
        Console.WriteLine($"Dentro de DuplicarValor: {x}");
    }
    
    // Paso por referencia (usa la misma dirección de memoria)
    static void DuplicarReferencia(ref int x)
    {
        x = x * 2;
        Console.WriteLine($"Dentro de DuplicarReferencia: {x}");
    }
}

// Clase de ejemplo para demostrar tipos de referencia
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
