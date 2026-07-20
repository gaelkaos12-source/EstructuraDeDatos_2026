using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Generador de Datos: 10,000 matrículas ordenadas (1 a 10,000)
        int[] matriculas = new int[10000];
        for (int i = 0; i < matriculas.Length; i++)
        {
            matriculas[i] = i + 1;
        }

        Console.WriteLine("==========================================================");
        Console.WriteLine("=== CLASE 15: MOTOR DE BÚSQUEDA DE MATRÍCULAS ESCOLARES ===");
        Console.WriteLine("==========================================================");
        Console.WriteLine($"Estatus del Arreglo: {matriculas.Length:N0} matrículas ordenadas.\n");

        // Solicitar matrícula al usuario
        Console.Write("Ingresa la matrícula a buscar: ");
        if (!int.TryParse(Console.ReadLine(), out int objetivo))
        {
            Console.WriteLine("Entrada inválida. Debe ser un número entero.");
            return;
        }

        // Ejecutar Búsquedas
        int idxLineal = BusquedaLineal(matriculas, objetivo, out int iterLineal);
        int idxBinaria = BusquedaBinaria(matriculas, objetivo, out int iterBinaria);

        // Imprimir Reporte de Comparación
        Console.WriteLine("\n=== REPORTE DE BÚSQUEDA ===");
        Console.WriteLine($"Tamaño del arreglo: {matriculas.Length:N0}");
        Console.WriteLine($"Matrícula objetivo: {objetivo}");

        if (idxLineal != -1)
            Console.WriteLine($"[Lineal] Encontrado en índice: {idxLineal}");
        else
            Console.WriteLine("[Lineal] No encontrado.");
        Console.WriteLine($"[Lineal] Iteraciones realizadas: {iterLineal}");

        if (idxBinaria != -1)
            Console.WriteLine($"[Binaria] Encontrado en índice: {idxBinaria}");
        else
            Console.WriteLine("[Binaria] No encontrado.");
        Console.WriteLine($"[Binaria] Iteraciones realizadas: {iterBinaria}");

        Console.WriteLine("\nObservación:");
        Console.WriteLine("La búsqueda lineal puede revisar casi todo el arreglo.");
        Console.WriteLine("La búsqueda binaria aprovecha que los datos están ordenados.");
    }

    // Algoritmo 1: Búsqueda Lineal O(n)
    static int BusquedaLineal(int[] arr, int objetivo, out int iteraciones)
    {
        iteraciones = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            iteraciones++;
            if (arr[i] == objetivo) return i;
        }
        return -1;
    }

    // Algoritmo 2: Búsqueda Binaria O(log n)
    static int BusquedaBinaria(int[] arr, int objetivo, out int iteraciones)
    {
        iteraciones = 0;
        int izquierda = 0, derecha = arr.Length - 1;

        while (izquierda <= derecha)
        {
            iteraciones++;
            int centro = izquierda + (derecha - izquierda) / 2;

            if (arr[centro] == objetivo)
                return centro;

            if (arr[centro] < objetivo)
                izquierda = centro + 1;
            else
                derecha = centro - 1;
        }
        return -1;
    }
}