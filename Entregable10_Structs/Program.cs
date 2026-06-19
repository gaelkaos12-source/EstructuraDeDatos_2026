using System;

Console.WriteLine("=== ENTREGABLE 10: TELEMETRÍA GPS CON STRUCTS ===");
Console.WriteLine("Autor: gaelkaos");
Console.WriteLine($"Fecha: {DateTime.Now:dd/MM/yyyy}\n");

// --- PRUEBA 1: Registro Exitoso de Coordenadas ---
Console.WriteLine("[1] Intentando registrar coordenadas válidas (Zócalo CDMX):");
try
{
    CoordenadasGps zocalo = new CoordenadasGps(19.4326, -99.1332);
    Console.WriteLine($"-> Coordenadas registradas con éxito: {zocalo}\n");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Error inesperado: {ex.Message}\n");
}

// --- PRUEBA 2: Validación de Rangos Erróneos ---
Console.WriteLine("[2] Intentando registrar coordenadas inválidas (Falla intencional):");
try
{
    // Latitud incorrecta (95.5 supera el límite de 90)
    CoordenadasGps coordenadaInvalida = new CoordenadasGps(95.5, -102.45);
    Console.WriteLine($"-> {coordenadaInvalida}\n");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine("-> Excepción capturada correctamente:");
    Console.WriteLine($"   Mensaje del sistema: {ex.ParamName} - {ex.Message}\n");
}


// ==========================================
//     ESTRUCTURAS PERSONALIZADAS (STRUCTS)
// ==========================================

// El modificador 'readonly' asegura que los datos sean inmutables en memoria
public readonly struct CoordenadasGps
{
    public double Latitud { get; }
    public double Longitud { get; }

    // Constructor con validación estricta de rangos geográficos
    public CoordenadasGps(double latitud, double longitud)
    {
        // La latitud debe estar estrictamente entre -90 y 90 grados
        if (latitud < -90 || latitud > 90)
        {
            throw new ArgumentOutOfRangeException(nameof(latitud), "La latitud debe estar comprendida entre -90 y 90 grados.");
        }

        // La longitud debe estar estrictamente entre -180 y 180 grados
        if (longitud < -180 || longitud > 180)
        {
            throw new ArgumentOutOfRangeException(nameof(longitud), "La longitud debe estar comprendida entre -180 y 180 grados.");
        }

        Latitud = latitud;
        Longitud = longitud;
    }

    // Sobrescritura para formatear la salida en consola
    public override string ToString()
    {
        return $"Latitud: {Latitud:F4}°, Longitud: {Longitud:F4}°";
    }
}

/* =========================================================================
   ===                  ANÁLISIS TEÓRICO DEL ENTREGABLE 10               ===
   =========================================================================
   
   1. SEMÁNTICA DE MEMORIA: STACK VS HEAP
      - Al declarar 'CoordenadasGps' como un struct, la instancia completa se aloja 
        directamente en la memoria Stack (Pila). Su asignación y liberación es instantánea
        y no requiere que el Garbage Collector intervenga (evitando sobrecarga).
      - Si fuera una clase, los datos vivirían en el Heap, requiriendo un puntero de 
        referencia de 8 bytes en el Stack hacia el objeto real.

   2. LA IMPORTANCIA DE LA INMUTABILIDAD (readonly):
      - Definir propiedades con solo lectura asegura que el estado del struct no cambie 
        después de su creación. Si pasamos el struct a múltiples métodos, C# copia los 
        valores por valor de forma segura, garantizando que ninguna función externa modifique 
        los datos originales de telemetría accidentalmente.
*/