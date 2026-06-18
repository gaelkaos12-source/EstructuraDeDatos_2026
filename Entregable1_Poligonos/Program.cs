using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("== Calculadora de Polígonos ==");
        Console.WriteLine("Selecciona un polígono:");
        Console.WriteLine("5 – Pentágono");
        Console.WriteLine("6 – Hexágono");
        Console.WriteLine("7 – Heptágono");
        Console.WriteLine("8 – Octágono");
        
        Console.Write("Número de lados: ");
        int lados = int.Parse(Console.ReadLine());
        
        Console.Write("Ingresa la medida del lado: ");
        double lado = double.Parse(Console.ReadLine());
        
        Console.Write("Ingresa la medida de la apotema: ");
        double apotema = double.Parse(Console.ReadLine());
        
        double area = (lados * lado * apotema) / 2;
        
        Console.WriteLine($"El área del polígono es: {area:F2}");
    }
}