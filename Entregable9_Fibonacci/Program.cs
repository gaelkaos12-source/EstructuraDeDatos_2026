using System;
using System.Collections.Generic;
using System.Diagnostics; // REQUERIDO PARA STOPWATCH

Console.WriteLine("=== ENTREGABLE 9: OPTIMIZACIÓN ALGORÍTMICA (MEMOIZATION) ===");
Console.WriteLine("Autor: gaelkaos");
Console.WriteLine($"Fecha: {DateTime.Now:dd/MM/yyyy}\n");

// Diccionario global para la técnica de Memoization
Dictionary<int, long> memoriaFibonacci = new Dictionary<int, long>();

// Probaremos con un número intermedio (por ejemplo 40) donde la diferencia es abismal
int nPrueba = 40; 

Console.WriteLine($"--- Ejecutando pruebas de rendimiento para Fibonacci({nPrueba}) --- \n");

// --- PRUEBA 1: ENFOQUE TRADICIONAL INEFICIENTE ---
Console.WriteLine("[1] Iniciando Fibonacci Recursivo Tradicional...");
Stopwatch swTradicional = Stopwatch.StartNew();
long resTradicional = FibonacciTradicional(nPrueba);
swTradicional.Stop();

Console.WriteLine($"Resultado Tradicional: {resTradicional}");
Console.WriteLine($"Tiempo transcurrido: {swTradicional.ElapsedMilliseconds} ms\n");


// --- PRUEBA 2: ENFOQUE OPTIMIZADO (MEMOIZATION) ---
Console.WriteLine("[2] Iniciando Fibonacci con Memoization...");
Stopwatch swOptimizado = Stopwatch.StartNew();
long resOptimizado = FibonacciMemoization(nPrueba, memoriaFibonacci);
swOptimizado.Stop();

Console.WriteLine($"Resultado Optimizado: {resOptimizado}");
Console.WriteLine($"Tiempo transcurrido: {swOptimizado.ElapsedMilliseconds} ms (¡Prácticamente instantáneo!)\n");


// ==========================================
//           ALGORITMOS Y MÉTODOS
// ==========================================

// 1. Fibonacci Tradicional - Complejidad Exponencial O(2^n)
long FibonacciTradicional(int n)
{
    if (n == 0) return 0;
    if (n == 1) return 1;
    
    // Genera subárboles redundantes repitiendo cálculos en memoria constantemente
    return FibonacciTradicional(n - 1) + FibonacciTradicional(n - 2);
}

// 2. Fibonacci Optimizado - Complejidad Lineal O(n) utilizando un caché dinámico
long FibonacciMemoization(int n, Dictionary<int, long> memoria)
{
    if (n == 0) return 0;
    if (n == 1) return 1;

    // Si ya calculamos este valor previamente, lo regresamos del caché de inmediato
    if (memoria.ContainsKey(n))
    {
        return memoria[n];
    }

    // Si no existe, lo calculamos, lo guardamos en el diccionario y lo devolvemos
    memoria[n] = FibonacciMemoization(n - 1, memoria) + FibonacciMemoization(n - 2, memoria);
    return memoria[n];
}

/* =========================================================================
   ===                  ANÁLISIS TEÓRICO DEL ENTREGABLE 9                ===
   =========================================================================
   
   1. EXPLICACIÓN DE LA DEFICIENCIA TRADICIONAL O(2^n):
      - El algoritmo tradicional duplica el número de llamadas con cada nivel de profundidad 
        (crea un árbol binario completo de llamadas redundantes). Para calcular Fibonacci(40), 
        repite el cálculo de valores pequeños millones de veces de forma innecesaria saturando la CPU.

   2. ¿CÓMO SOLUCIONA EL PROBLEMA LA TÉCNICA DE MEMOIZATION O(n)?
      - Consiste en almacenar los resultados de subproblemas ya resueltos en una estructura (Caché).
        Al transformar la recursividad mediante tablas o Diccionarios, el costo temporal pasa de ser 
        Exponencial a Lineal, disminuyendo los ciclos de procesamiento drásticamente.
*/