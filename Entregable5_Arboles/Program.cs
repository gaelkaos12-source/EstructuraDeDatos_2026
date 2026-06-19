using System;

Console.WriteLine("=== ÁRBOLES BINARIOS DE BÚSQUEDA (BST) ===\n");

ArbolBinario arbol = new ArbolBinario();

// Insertar nodos de ejemplo
arbol.Insertar(50);
arbol.Insertar(30);
arbol.Insertar(70);
arbol.Insertar(20);
arbol.Insertar(40);
arbol.Insertar(60);
arbol.Insertar(80);

Console.WriteLine("Recorrido Preorden (Raíz, Izquierda, Derecha):");
arbol.RecorrerPreorden();

Console.WriteLine("Recorrido Inorden (Izquierda, Raíz, Derecha) -> ¡Ordenado!:");
arbol.RecorrerInorden();

Console.WriteLine("Recorrido Postorden (Izquierda, Derecha, Raíz):");
arbol.RecorrerPostorden();


// --- ESTRUCTURA DEL ÁRBOL BINARIO ---

public class Nodo
{
    public int Valor { get; set; }
    public Nodo? Izquierdo { get; set; } // El '?' quita los warnings de valores nulos
    public Nodo? Derecho { get; set; }

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

public class ArbolBinario
{
    private Nodo? raiz; // El '?' aclara que el árbol puede empezar vacío

    public ArbolBinario()
    {
        raiz = null;
    }

    public void Insertar(int valor)
    {
        raiz = InsertarRecursivo(raiz, valor);
    }

    private Nodo InsertarRecursivo(Nodo? actual, int valor)
    {
        if (actual == null)
        {
            return new Nodo(valor);
        }

        if (valor < actual.Valor)
        {
            actual.Izquierdo = InsertarRecursivo(actual.Izquierdo, valor);
        }
        else if (valor > actual.Valor)
        {
            actual.Derecho = InsertarRecursivo(actual.Derecho, valor);
        }

        return actual;
    }

    // --- RECORRIDOS RECURSIVOS ---

    public void RecorrerPreorden()
    {
        Preorden(raiz);
        Console.WriteLine("\n");
    }

    private void Preorden(Nodo? nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " "); // Corregido: Se eliminó la línea con error
            Preorden(nodo.Izquierdo);
            Preorden(nodo.Derecho);
        }
    }

    public void RecorrerInorden()
    {
        Inorden(raiz);
        Console.WriteLine("\n");
    }

    private void Inorden(Nodo? nodo)
    {
        if (nodo != null)
        {
            Inorden(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            Inorden(nodo.Derecho);
        }
    }

    public void RecorrerPostorden()
    {
        Postorden(raiz);
        Console.WriteLine("\n");
    }

    private void Postorden(Nodo? nodo)
    {
        if (nodo != null)
        {
            Postorden(nodo.Izquierdo);
            Postorden(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }
}