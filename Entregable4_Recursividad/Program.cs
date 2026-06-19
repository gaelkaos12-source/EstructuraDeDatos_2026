using System;

Console.WriteLine("=== ALGORITMOS RECURSIVOS ===\n");

// --- SECCIÓN 1: FACTORIAL ---
Console.Write("Ingresa un número para calcular su factorial: ");
if (int.TryParse(Console.ReadLine(), out int numFactorial))
{
    try
    {
        long resultadoFactorial = CalcularFactorial(numFactorial);
        Console.WriteLine($"{numFactorial}! = {resultadoFactorial}\n");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}\n");
    }
}
else
{
    Console.WriteLine("Error: Entrada no válida.\n");
}

// --- SECCIÓN 2: FIBONACCI ---
Console.Write("Ingresa la posición de Fibonacci (n): ");
if (int.TryParse(Console.ReadLine(), out int numFibonacci))
{
    try
    {
        long resultadoFibonacci = CalcularFibonacci(numFibonacci);
        Console.WriteLine($"Fibonacci({numFibonacci}) = {resultadoFibonacci}\n");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}\n");
    }
}
else
{
    Console.WriteLine("Error: Entrada no válida.\n");
}


// --- MÉTODOS RECURSIVOS ---

// Función para calcular Factorial de forma recursiva
long CalcularFactorial(int n)
{
    if (n < 0)
    {
        throw new ArgumentException("El número no puede ser negativo.");
    }
    
    // Casos base
    if (n == 0 || n == 1)
    {
        return 1;
    }
    
    // Paso recursivo
    return n * CalcularFactorial(n - 1);
}

// Función para calcular Fibonacci de forma recursiva
long CalcularFibonacci(int n)
{
    if (n < 0)
    {
        throw new ArgumentException("La posición no puede ser negativa.");
    }
    
    // Casos base
    if (n == 0) return 0;
    if (n == 1) return 1;
    
    // Paso recursivo
    return CalcularFibonacci(n - 1) + CalcularFibonacci(n - 2);
}
