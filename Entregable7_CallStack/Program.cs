using System;

Console.WriteLine("=== SIMULADOR DEL CALL STACK ===");
Console.WriteLine("Autor: gaelkaos");
Console.WriteLine($"Fecha: {DateTime.Now:dd/MM/yyyy}\n");

// --- EJERCICIO A: Cuenta Regresiva ---
Console.WriteLine("=== EJERCICIO A: Cuenta Regresiva ===");
Console.WriteLine("Demostración del comportamiento LIFO del Call Stack:");
ImprimirCuentaRegresiva(3);
Console.WriteLine();

// --- EJERCICIO B: Sumatoria Recursiva ---
Console.WriteLine("=== EJERCICIO B: Sumatoria Recursiva ===");
Console.Write("Introduce un número entero positivo: ");
string? entrada = Console.ReadLine();

if (int.TryParse(entrada, out int numeroValidado) && numeroValidado >= 0)
{
    int resultadoSumatoria = CalcularSumatoria(numeroValidado);
    Console.WriteLine($"La sumatoria recursiva de 1 hasta {numeroValidado} es: {resultadoSumatoria}\n");
}
else
{
    Console.WriteLine("Error: Entrada no válida. Debe ser un número entero mayor o igual a cero.\n");
}

// --- EJERCICIO EXTRA C: Demostración de Stack Overflow (Opcional) ---
Console.WriteLine("=== EJERCICIO EXTRA: ¿Quieres simular un error Stack Overflow? (s/n) ===");
string? respuesta = Console.ReadLine()?.ToLower();
if (respuesta == "s")
{
    Console.WriteLine("Provocando desbordamiento de pila en 3, 2, 1...");
    SimularStackOverflow(1);
}


// ==========================================
//           MÉTODOS RECURSIVOS
// ==========================================

// Ejercicio A: Cuenta Regresiva con traza del Call Stack (LIFO)
void ImprimirCuentaRegresiva(int n)
{
    if (n == 0)
    {
        Console.WriteLine("  [DESPEGUE] ¡Caso base alcanzado!");
        return;
    }

    Console.WriteLine($"  [APILANDO] Marco para número: {n}");
    ImprimirCuentaRegresiva(n - 1);
    Console.WriteLine($"  [LIBERANDO] Marco para número: {n}");
}

// Ejercicio B: Sumatoria de 1 hasta N
int CalcularSumatoria(int n)
{
    if (n == 0) return 0;
    return n + CalcularSumatoria(n - 1);
}

// Extra: Método infinito que satura el tamaño asignado al hilo en la Pila (Stack)
void SimularStackOverflow(int n)
{
    // Al omitir el caso base, la pila crece indefinidamente hasta romper el programa
    SimularStackOverflow(n + 1);
}


/* =========================================================================
   ===            PASO EXTRA: ANÁLISIS TEÓRICO DE LA PRÁCTICA            ===
   =========================================================================
   
   1. COMPLEJIDAD TEMPORAL Y ESPACIAL (NOTACIÓN BIG O):
      - Cuenta Regresiva y Sumatoria: Su complejidad temporal es O(n) porque realiza 
        exactamente 'n' llamadas recursivas individuales.
      - Complejidad Espacial: Es O(n) debido a que cada llamada recursiva retiene un 
        marco de activación (stack frame) en la memoria Stack (Pila) esperando la 
        resolución del caso base.

   2. ¿QUÉ ES UN STACK OVERFLOW Y POR QUÉ OCURRE?:
      - Un desbordamiento de pila (Stack Overflow) ocurre cuando el Call Stack se queda 
        sin memoria disponible para alojar nuevos marcos de activación.
      - Causas principales: 
         a) Ausencia de un caso base que detenga la recursión.
         b) Condiciones de parada mal diseñadas (casos base inalcanzables).
         c) Una profundidad de recursión excesivamente grande que supera el límite 
            de memoria física del hilo (habitualmente 1MB en entornos de consola .NET).
*/