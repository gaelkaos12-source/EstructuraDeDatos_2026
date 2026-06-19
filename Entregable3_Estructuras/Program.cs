using System;
using System.Collections.Generic;
using System.Linq;

// Paso 3: Construyendo el Inventario y ejecución del programa
Console.WriteLine("=== SISTEMA DE INVENTARIO CLASE 3 ===\n");

// Inicialización de la lista de productos (Sintaxis 1)
List<Producto> inventario = new List<Producto>
{
    new Producto(1, "Laptop Lenovo", 15999.00, 10),
    new Producto(2, "Mouse Inalámbrico", 349.00, 25),
    new Producto(3, "Teclado Mecánico", 899.00, 0),
    new Producto(4, "Monitor 24\"", 4500.00, 5),
    new Producto(5, "Audífonos Sony", 1200.00, 0)
};

// Agregar elementos con Sintaxis 2
inventario.Add(new Producto(6, "Webcam HD", 750.00, 12));

// Agregar elementos con Sintaxis 3 (var)
var otroProducto = new Producto(7, "Hub USB-C", 450.00, 8);
inventario.Add(otroProducto);

Console.WriteLine($"Total en inventario: {inventario.Count} productos\n");

// Paso 4: Consultas LINQ
// Consulta 1: Ordenar por precio descendente
var porPrecio = inventario.OrderByDescending(p => p.Precio).ToList();
Console.WriteLine("=== Productos por Precio (Mayor a Menor) ===");
foreach (var p in porPrecio)
{
    Console.WriteLine(p);
}
Console.WriteLine();

// Consulta 2: Filtrar productos agotados (Cantidad == 0)
var agotados = inventario.Where(p => p.Cantidad == 0).ToList();
Console.WriteLine("=== Productos Agotados ===");
if (agotados.Count == 0)
{
    Console.WriteLine("Sin productos agotados.");
}
else
{
    foreach (var p in agotados)
    {
        Console.WriteLine(p);
    }
}
Console.WriteLine();

// Paso 5: Diccionario para búsqueda rápida por ID
Dictionary<int, Producto> catalogo = inventario.ToDictionary(p => p.ID, p => p);

Console.WriteLine("=== Búsqueda por ID (Dictionary) ===");
Console.Write("Ingresa el ID del producto a buscar: ");

if (int.TryParse(Console.ReadLine(), out int idBuscado))
{
    if (catalogo.TryGetValue(idBuscado, out Producto encontrado))
    {
        Console.WriteLine($"Producto encontrado: {encontrado}");
    }
    else
    {
        Console.WriteLine($"No se encontró ningún producto con ID {idBuscado}.");
    }
}
else
{
    Console.WriteLine("ID inválido. Debe ser un número entero.");
}


// Paso 2: Modelo de Datos Clase Producto (definido abajo usando C# moderno)
public class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(int id, string nombre, double precio, int cantidad)
    {
        ID = id;
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }

    public override string ToString()
    {
        return $"ID: {ID} | {Nombre} - ${Precio:F2} | Stock: {Cantidad}";
    }
}
