using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== DEMONIO DE LA MEMORIA: STACK vs HEAP ===\n");

        // --- VALOR (Value Type) ---
        int numeroOriginal = 5;
        Console.WriteLine($"Antes de llamar a CambiarValor: {numeroOriginal}");
        CambiarValor(numeroOriginal);
        Console.WriteLine($"Después de llamar a CambiarValor: {numeroOriginal}");
        Console.WriteLine("Explicación: El valor NO cambió porque 'int' es un Value Type (se pasa una copia).\n");

        // --- REFERENCIA (Reference Type) ---
        int[] arregloOriginal = { 1, 2, 3 };
        Console.WriteLine($"Antes de llamar a CambiarReferencia: [{string.Join(", ", arregloOriginal)}]");
        CambiarReferencia(arregloOriginal);
        Console.WriteLine($"Después de llamar a CambiarReferencia: [{string.Join(", ", arregloOriginal)}]");
        Console.WriteLine("Explicación: El valor SÍ cambió porque 'int[]' es un Reference Type (se pasa la dirección).\n");

        // --- VISUALIZACIÓN TEÓRICA ---
        Console.WriteLine("=== VISUALIZACIÓN EN MEMORIA ===");
        Console.WriteLine("Stack (Pila):");
        Console.WriteLine("  - numeroOriginal = 5 (Valor directo)");
        Console.WriteLine("  - arregloOriginal = [Dirección 0x1234] (Puntero al Heap)");
        Console.WriteLine("\nHeap (Montón):");
        Console.WriteLine("  - [Dirección 0x1234] → { 1, 2, 3 } (Datos reales)");
    }

    // Función 1: Value Type
    static void CambiarValor(int x)
    {
        x = 100;
        Console.WriteLine($"  Dentro de CambiarValor: x = {x} (solo cambió la copia)");
    }

    // Función 2: Reference Type
    static void CambiarReferencia(int[] arr)
    {
        arr[0] = 100;
        Console.WriteLine($"  Dentro de CambiarReferencia: arr[0] = {arr[0]} (cambió el original)");
    }
}