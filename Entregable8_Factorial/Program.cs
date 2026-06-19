using System;
using System.Numerics; // REQUERIDO PARA BigInteger

Console.WriteLine("=== ENTREGABLE 8: GESTIÓN DE DESBORDAMIENTO (OVERFLOW) ===");
Console.WriteLine("Autor: gaelkaos");
Console.WriteLine($"Fecha: {DateTime.Now:dd/MM/yyyy}\n");

// --- MÓDULO 1: El Límite del Int32 (Desbordamiento Silencioso) ---
Console.WriteLine("=== MÓDULO 1: Demostración con int (Límite de 32 bits) ===");
Console.WriteLine("Calculando factorial de 12 e 13 de forma recursiva e iterativa:");

int rec12 = FactorialIntRecursivo(12);
int ite12 = FactorialIntIterativo(12);
Console.WriteLine($"12! -> Recursivo: {rec12} | Iterativo: {ite12} (Correcto)");

// Aquí ocurre el desbordamiento silencioso (Overflow)
int rec13 = FactorialIntRecursivo(13);
int ite13 = FactorialIntIterativo(13);
Console.WriteLine($"13! -> Recursivo: {rec13} | Iterativo: {ite13} (¡CORRUPTO / OVERFLOW!)");

Console.WriteLine("\nExplicación: El desbordamiento silencioso comienza exactamente en 13!");
Console.WriteLine("13! real es 6,227,020,800, pero el máximo de un 'int' es 2,147,483,647.");
Console.WriteLine("Al superarse, los bits se desbordan invirtiendo el signo o alterando el valor.\n");


// --- MÓDULO 2: Solución Profesional con BigInteger ---
Console.WriteLine("=== MÓDULO 2: Factorial Profesional con BigInteger ===");
Console.Write("Ingresa un número entero para calcular su factorial masivo (Ej. 100): ");
string? entrada = Console.ReadLine();

if (int.TryParse(entrada, out int n) && n >= 0)
{
    BigInteger resultadoMasivo = CalcularFactorialBigInteger(n);
    Console.WriteLine($"\nEl factorial de {n}! es:\n{resultadoMasivo}\n");
    Console.WriteLine($"Total de dígitos aproximados: {resultadoMasivo.ToString().Length}");
}
else
{
    Console.WriteLine("Error: Entrada no válida. Debe ser un número entero mayor o igual a cero.\n");
}


// ==========================================
//           MÉTODOS Y ALGORITMOS
// ==========================================

// 1. Factorial con int - Enfoque Recursivo
int FactorialIntRecursivo(int n)
{
    if (n == 0 || n == 1) return 1;
    return n * FactorialIntRecursivo(n - 1);
}

// 2. Factorial con int - Enfoque Iterativo
int FactorialIntIterativo(int n)
{
    int resultado = 1;
    for (int i = 2; i <= n; i++)
    {
        resultado *= i;
    }
    return resultado;
}

// 3. Solución Eficiente con BigInteger (Soporta precisión arbitraria de n dígitos)
BigInteger CalcularFactorialBigInteger(int n)
{
    BigInteger resultado = 1;
    for (int i = 2; i <= n; i++)
    {
        resultado *= i;
    }
    return resultado;
}

/* =========================================================================
   ===                  ANÁLISIS TEÓRICO DEL ENTREGABLE 8                ===
   =========================================================================
   
   1. ¿POR QUÉ OCURRE EL OVERFLOW EN 13! CON EL TIPO INT?
      - El tipo 'int' en C# es un Int32 con signo (ocupa 4 bytes / 32 bits). El valor 
        máximo positivo que puede almacenar es 2^31 - 1 = 2,147,483,647.
      - Como 13! equivale a 6,227,020,800, los bits exceden la capacidad del registro,
        lo que causa un desbordamiento cíclico que altera drásticamente el resultado.

   2. SOLUCIÓN CON BigInteger:
      - BigInteger no tiene un límite fijo superior o inferior. Crece de manera dinámica 
        en la memoria Heap del sistema, estando limitado únicamente por la memoria RAM 
        disponible en la computadora. Es ideal para criptografía y cálculos científicos masivos.
*/