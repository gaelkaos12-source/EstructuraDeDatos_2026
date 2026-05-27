using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Calculadora de Polígonos ===\n");
        
        int lados = SeleccionarPoligono();
        double lado = PedirDato("Ingresa la medida del lado: ");
        double apotema = PedirDato("Ingresa la medida de la apotema: ");
        
        double area = CalcularArea(lados, lado, apotema);
        
        Console.WriteLine($"\nEl área del polígono es: {area:F2}");
    }

    static int SeleccionarPoligono()
    {
        Console.WriteLine("Selecciona un polígono:");
        Console.WriteLine("5 – Pentágono");
        Console.WriteLine("6 – Hexágono");
        Console.WriteLine("7 – Heptágono");
        Console.WriteLine("8 – Octágono");
        
        Console.Write("Número de lados: ");
        
        int lados;
        while (!int.TryParse(Console.ReadLine(), out lados) || lados < 5 || lados > 8)
        {
            Console.Write("Opción inválida. Ingresa 5, 6, 7 u 8: ");
        }
        
        return lados;
    }

    static double PedirDato(string mensaje)
    {
        double valor;
        Console.Write(mensaje);
        while (!double.TryParse(Console.ReadLine(), out valor) || valor <= 0)
        {
            Console.Write("Valor inválido. Debe ser número positivo: ");
        }
        return valor;
    }

    static double CalcularArea(int lados, double lado, double apotema)
    {
        double perimetro = lados * lado;
        double area = (perimetro * apotema) / 2;
        return area;
    }
}