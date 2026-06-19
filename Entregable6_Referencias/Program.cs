using System;

Console.WriteLine("=== ENTREGABLE 6: REFERENCIAS Y MEMORIA ===\n");

// --- MÓDULO 1: Intercambiador con ref ---
Console.WriteLine("--- MÓDULO 1: Intercambio con ref ---");
int a = 10, b = 25;
Console.WriteLine($"Antes del intercambio: a = {a}, b = {b}");
Intercambiar(ref a, ref b);
Console.WriteLine($"Después del intercambio: a = {a}, b = {b}\n");

// --- MÓDULO 2: CalcularYValidar con out ---
Console.WriteLine("--- MÓDULO 2: CalcularYValidar con out ---");
int dividendo = 17, divisor = 5;
int cociente = CalcularYValidar(dividendo, divisor, out int residuo);
Console.WriteLine($"Dividendo: {dividendo} | Divisor: {divisor}");
Console.WriteLine($"Resultado -> Cociente: {cociente} | Residuo: {residuo}\n");

// --- MÓDULO 3: Referencias de Objetos ---
Console.WriteLine("--- MÓDULO 3: Referencias de Objetos ---");
Alumno alumno1 = new Alumno("Dany");
Alumno alumno2 = alumno1; // Copia la dirección de memoria, no el objeto

Console.WriteLine($"Nombre Alumno 1: {alumno1.Nombre}");
Console.WriteLine($"Nombre Alumno 2: {alumno2.Nombre}");

Console.WriteLine("-> Modificando el nombre a través de Alumno 2...");
alumno2.Nombre = "Gael";

Console.WriteLine($"Nombre Alumno 1 (afectado): {alumno1.Nombre}");
Console.WriteLine($"Nombre Alumno 2: {alumno2.Nombre}\n");


// --- MÉTODOS Y CLASES ---

// Módulo 1: Uso de ref
static void Intercambiar(ref int x, ref int y)
{
    int temp = x;
    x = y;
    y = temp;
}

// Módulo 2: Uso de out
static int CalcularYValidar(int div, int dis, out int resto)
{
    resto = div % dis; // Asignación obligatoria debido a 'out'
    return div / dis;
}

// Módulo 3: Clase Alumno
public class Alumno
{
    public string Nombre { get; set; }

    public Alumno(string nombre)
    {
        Nombre = nombre;
    }
}