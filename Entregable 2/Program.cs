Console.WriteLine("Hello, World!");
using System;

int numeroOriginal = 5;
int[] arregloOriginal = { 1, 2, 3 };

Console.WriteLine($"Antes de llamar a CambiarValor: {numeroOriginal}");
CambiarValor(numeroOriginal);
Console.WriteLine($"Después de llamar a CambiarValor: {numeroOriginal}");
Console.WriteLine("Explicación: El valor NO cambió porque int es un Value Type (se pasa una copia).\n");

Console.WriteLine($"Antes de llamar a CambiarReferencia: [{string.Join(", ", arregloOriginal)}]");
CambiarReferencia(arregloOriginal);
Console.WriteLine($"Después de llamar a CambiarReferencia: [{string.Join(", ", arregloOriginal)}]");
Console.WriteLine("Explicación: El valor SÍ cambió porque int[] es un Reference Type (se pasa la dirección).\n");

Console.WriteLine("=== VISUALIZACIÓN EN MEMORIA ===");
Console.WriteLine("Stack (Pila):");
Console.WriteLine("  numeroOriginal = 5 (Valor directo)");
Console.WriteLine("  arregloOriginal -> [Dirección 0x1234] (Puntero al Heap)");
Console.WriteLine("\nHeap (Montón):");
Console.WriteLine("  [Dirección 0x1234] -> { 100, 2, 3 } (Datos reales modificados)");

void CambiarValor(int x)
{
    x = 100;
}

void CambiarReferencia(int[] arr)
{
    arr[0] = 100;
}