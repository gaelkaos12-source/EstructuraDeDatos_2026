using System;

namespace DataCore.Fase3
{
    // 1. DATO INMUTABLE
    public readonly struct RegistroDatos
    {
        public int Id { get; }
        public string Nombre { get; }
        public decimal Monto { get; }

        public RegistroDatos(int id, string nombre, decimal monto)
        {
            Id = id;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Monto = monto;
        }

        public override string ToString()
        {
            return $"Id: {Id,2} | Nombre: {Nombre,-15} | Monto: {Monto,8:C}";
        }
    }

    // 2. CLASE NODO EN EL HEAP
    public class NodoRegistro
    {
        public RegistroDatos Dato { get; set; }
        public NodoRegistro? Siguiente { get; set; }

        public NodoRegistro(RegistroDatos dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // 3. TABLA DINÁMICA (LISTA SIMPLEMENTE ENLAZADA)
    public class TablaDinamica
    {
        private NodoRegistro? cabeza;
        private int contadorRegistros;

        public TablaDinamica()
        {
            cabeza = null;
            contadorRegistros = 0;
        }

        public void InsertarInicio(RegistroDatos nuevoRegistro)
        {
            NodoRegistro nuevoNodo = new NodoRegistro(nuevoRegistro);
            nuevoNodo.Siguiente = cabeza;
            cabeza = nuevoNodo;
            contadorRegistros++;
        }

        public void InsertarFinal(RegistroDatos nuevoRegistro)
        {
            NodoRegistro nuevoNodo = new NodoRegistro(nuevoRegistro);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoRegistro actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
            contadorRegistros++;
        }

        public void EliminarPorId(int idTarget)
        {
            if (cabeza == null) return;

            // Caso especial: eliminar la cabeza
            if (cabeza.Dato.Id == idTarget)
            {
                cabeza = cabeza.Siguiente;
                contadorRegistros--;
                return;
            }

            NodoRegistro anterior = cabeza;
            NodoRegistro? actual = cabeza.Siguiente;

            while (actual != null)
            {
                if (actual.Dato.Id == idTarget)
                {
                    anterior.Siguiente = actual.Siguiente;
                    contadorRegistros--;
                    return;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
        }

        // PUENTE DE INTEROPERABILIDAD
        public RegistroDatos[] ObtenerComoArreglo()
        {
            RegistroDatos[] resultado = new RegistroDatos[contadorRegistros];
            NodoRegistro? actual = cabeza;
            int i = 0;

            while (actual != null)
            {
                resultado[i] = actual.Dato;
                actual = actual.Siguiente;
                i++;
            }

            return resultado;
        }
    }

    // 4. ORQUESTADOR PRINCIPAL (MAIN)
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine(" PROJECT DATACORE - FASE 3: LINKED LIST & HEAP");
            Console.WriteLine(" Estudiante: Gael Alberto Gomez Baltazar");
            Console.WriteLine(" Correo: gael.gomez33@my.unitec.edu.mx");
            Console.WriteLine("=================================================\n");

            // Instanciar la estructura dinámica
            TablaDinamica dataCore = new TablaDinamica();

            // Paso 1: Insertar 15 registros dinámicos
            for (int i = 1; i <= 15; i++)
            {
                RegistroDatos reg = new RegistroDatos(i, $"Transacción-{i}", i * 100.0m);
                dataCore.InsertarFinal(reg);
                Console.WriteLine($"[INSERT] Registro {i} añadido a la cadena.");
            }

            // Paso 2: Eliminar 2 registros específicos
            Console.WriteLine("\n--- Eliminando registros con Id 5 y Id 11 ---");
            dataCore.EliminarPorId(5);
            dataCore.EliminarPorId(11);
            Console.WriteLine("Cadena reestructurada exitosamente. Sin NullReferenceException.");

            // Paso 3: Convertir a arreglo e Interoperabilidad
            RegistroDatos[] arreglo = dataCore.ObtenerComoArreglo();
            Console.WriteLine($"\nRegistros en arreglo: {arreglo.Length} (esperado: 13)");

            // Paso 4: Ordenamiento con QuickSort
            QuickSort(arreglo, 0, arreglo.Length - 1);

            Console.WriteLine("\n--- Arreglo ordenado por Id (QuickSort) ---");
            foreach (var r in arreglo)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("\n=================================================");
            Console.WriteLine(" EJECUCIÓN FASE 3 COMPLETADA EXITOSAMENTE");
            Console.WriteLine("=================================================");
        }

        // Algoritmo QuickSort heredado
        private static void QuickSort(RegistroDatos[] arreglo, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int pivoteIndice = Particionar(arreglo, izquierda, derecha);
                QuickSort(arreglo, izquierda, pivoteIndice - 1);
                QuickSort(arreglo, pivoteIndice + 1, derecha);
            }
        }

        private static int Particionar(RegistroDatos[] arreglo, int izquierda, int derecha)
        {
            int pivote = arreglo[derecha].Id;
            int i = izquierda - 1;

            for (int j = izquierda; j < derecha; j++)
            {
                if (arreglo[j].Id <= pivote)
                {
                    i++;
                    (arreglo[i], arreglo[j]) = (arreglo[j], arreglo[i]);
                }
            }

            (arreglo[i + 1], arreglo[derecha]) = (arreglo[derecha], arreglo[i + 1]);
            return i + 1;
        }
    }
}