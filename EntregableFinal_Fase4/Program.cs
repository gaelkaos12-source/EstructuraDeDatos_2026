using System;
using System.Collections.Generic;

namespace DataCore
{
    public class RegistroDatos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public double Valor { get; set; }

        public override string ToString()
        {
            return $"[ID: {Id:D4} | Nombre: {Nombre,-15} | Valor: {Valor,8:C2}]";
        }
    }

    public class Nodo
    {
        public RegistroDatos Dato { get; set; }
        public Nodo? Siguiente { get; set; }

        public Nodo(RegistroDatos dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    public class TablaDinamica
    {
        private Nodo? cabeza;
        public int CantidadRegistros { get; private set; }

        public TablaDinamica()
        {
            cabeza = null;
            CantidadRegistros = 0;
        }

        public void Insertar(RegistroDatos nuevoRegistro)
        {
            Nodo nuevoNodo = new Nodo(nuevoRegistro);
            nuevoNodo.Siguiente = cabeza;
            cabeza = nuevoNodo;
            CantidadRegistros++;
        }

        public bool EliminarPorId(int id)
        {
            if (cabeza == null) return false;

            if (cabeza.Dato.Id == id)
            {
                cabeza = cabeza.Siguiente;
                CantidadRegistros--;
                return true;
            }

            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato.Id == id)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    CantidadRegistros--;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        public void MostrarTodos()
        {
            if (cabeza == null)
            {
                Console.WriteLine("-> No hay registros en memoria.");
                return;
            }

            Nodo? actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);
                actual = actual.Siguiente;
            }
        }

        public RegistroDatos[] ObtenerArregloSinNulos()
        {
            RegistroDatos[] arreglo = new RegistroDatos[CantidadRegistros];
            Nodo? actual = cabeza;
            int i = 0;
            while (actual != null && i < CantidadRegistros)
            {
                arreglo[i] = actual.Dato;
                actual = actual.Siguiente;
                i++;
            }
            return arreglo;
        }
    }

    public static class AlgoritmosOrdenamiento
    {
        public static void QuickSort(RegistroDatos[] arr, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                int pivote = Particionar(arr, izquierda, derecha);
                QuickSort(arr, izquierda, pivote - 1);
                QuickSort(arr, pivote + 1, derecha);
            }
        }

        private static int Particionar(RegistroDatos[] arr, int izquierda, int derecha)
        {
            int pivote = arr[derecha].Id;
            int i = izquierda - 1;

            for (int j = izquierda; j < derecha; j++)
            {
                if (arr[j].Id <= pivote)
                {
                    i++;
                    RegistroDatos temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            RegistroDatos tempPivote = arr[i + 1];
            arr[i + 1] = arr[derecha];
            arr[derecha] = tempPivote;

            return i + 1;
        }
    }

    public static class BusquedaIndexada
    {
        public static (RegistroDatos? Registro, int Comparaciones) BuscarRegistroIndexado(RegistroDatos[] arreglo, int idBuscado)
        {
            if (arreglo == null || arreglo.Length == 0) return (null, 0);

            int izquierda = 0;
            int derecha = arreglo.Length - 1;
            int comparaciones = 0;

            while (izquierda <= derecha)
            {
                int medio = izquierda + (derecha - izquierda) / 2;
                comparaciones++;

                if (arreglo[medio] == null)
                {
                    derecha = medio - 1;
                    continue;
                }

                if (arreglo[medio].Id == idBuscado) return (arreglo[medio], comparaciones);

                if (arreglo[medio].Id < idBuscado)
                    izquierda = medio + 1;
                else
                    derecha = medio - 1;
            }

            return (null, comparaciones);
        }
    }

    class Program
    {
        private static TablaDinamica tabla = new TablaDinamica();
        private static RegistroDatos[]? indiceOrdenado = null;

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                MostrarEncabezado();
                MostrarMenu();

                Console.Write("Seleccione una opción (1-6): ");
                string? entrada = Console.ReadLine();

                if (!int.TryParse(entrada, out opcion))
                {
                    MostrarMensajeError("Entrada inválida. Debe ingresar un número entero.");
                    Pausar();
                    continue;
                }

                ProcesarOpcion(opcion);

            } while (opcion != 6);
        }

        private static void MostrarEncabezado()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine("          DATACORE v4.0 - SISTEMA MAESTRO         ");
            Console.WriteLine("==================================================");
            Console.ResetColor();
            Console.WriteLine($"Estado del Índice: {(indiceOrdenado != null ? "ACTUALIZADO" : "REQUERIDO / DESACTUALIZADO")}");
            Console.WriteLine($"Registros en memoria: {tabla.CantidadRegistros}");
            Console.WriteLine("--------------------------------------------------");
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("1. Insertar Registro");
            Console.WriteLine("2. Eliminar por ID");
            Console.WriteLine("3. Mostrar Registros");
            Console.WriteLine("4. Indexar y Ordenar Datos");
            Console.WriteLine("5. Búsqueda Binaria Indexada");
            Console.WriteLine("6. Salir del Sistema");
            Console.WriteLine("--------------------------------------------------");
        }

        private static void ProcesarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1: EjecutarInsertar(); break;
                case 2: EjecutarEliminar(); break;
                case 3: EjecutarMostrar(); break;
                case 4: EjecutarIndexarYOrdenar(); break;
                case 5: EjecutarBusquedaBinaria(); break;
                case 6: EjecutarSalir(); break;
                default:
                    MostrarMensajeError("Opción fuera de rango (1-6).");
                    Pausar();
                    break;
            }
        }

        private static void EjecutarInsertar()
        {
            try
            {
                Console.WriteLine("\n--- INSERTAR REGISTRO ---");
                Console.Write("Ingrese ID (Entero): ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                    throw new FormatException("El ID debe ser un número entero válido.");

                Console.Write("Ingrese Nombre: ");
                string nombre = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(nombre))
                    throw new ArgumentException("El nombre no puede estar vacío.");

                Console.Write("Ingrese Valor: ");
                if (!double.TryParse(Console.ReadLine(), out double valor))
                    throw new FormatException("El Valor debe ser un número decimal válido.");

                tabla.Insertar(new RegistroDatos { Id = id, Nombre = nombre, Valor = valor });
                indiceOrdenado = null; 
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-> Registro insertado exitosamente. (Índice desactualizado)");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error: {ex.Message}");
            }
            Pausar();
        }

        private static void EjecutarEliminar()
        {
            try
            {
                Console.WriteLine("\n--- ELIMINAR REGISTRO ---");
                if (tabla.CantidadRegistros == 0)
                    throw new InvalidOperationException("No hay registros en la tabla para eliminar.");

                Console.Write("Ingrese ID a eliminar: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                    throw new FormatException("El ID debe ser entero.");

                bool eliminado = tabla.EliminarPorId(id);
                if (eliminado)
                {
                    indiceOrdenado = null;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-> Registro eliminado correctamente.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("-> No se encontró ningún registro con ese ID.");
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error: {ex.Message}");
            }
            Pausar();
        }

        private static void EjecutarMostrar()
        {
            Console.WriteLine("\n--- LISTADO DE REGISTROS (LISTA ENLAZADA) ---");
            tabla.MostrarTodos();
            Pausar();
        }

        private static void EjecutarIndexarYOrdenar()
        {
            try
            {
                Console.WriteLine("\n--- INDEXACIÓN Y ORDENAMIENTO DE DATOS ---");
                if (tabla.CantidadRegistros == 0)
                    throw new InvalidOperationException("La tabla está vacía. Inserte datos antes de indexar.");

                RegistroDatos[] auxiliar = tabla.ObtenerArregloSinNulos();
                AlgoritmosOrdenamiento.QuickSort(auxiliar, 0, auxiliar.Length - 1);
                indiceOrdenado = auxiliar;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-> Índice generado y ordenado en memoria exitosamente.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error: {ex.Message}");
            }
            Pausar();
        }

        private static void EjecutarBusquedaBinaria()
        {
            try
            {
                Console.WriteLine("\n--- BÚSQUEDA BINARIA INDEXADA O(log n) ---");

                if (indiceOrdenado == null || indiceOrdenado.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Aviso: El índice no está actualizado. Ejecutando indexado automático...");
                    Console.ResetColor();
                    EjecutarIndexarYOrdenar();
                    if (indiceOrdenado == null) return;
                }

                Console.Write("Ingrese el ID a buscar: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                    throw new FormatException("El ID debe ser numérico.");

                var (registro, comparaciones) = BusquedaIndexada.BuscarRegistroIndexado(indiceOrdenado, id);

                Console.WriteLine("--------------------------------------------------");
                if (registro != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"-> REGISTRO ENCONTRADO: {registro}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-> RESULTADO: Registro NO encontrado.");
                    Console.ResetColor();
                }
                Console.WriteLine($"-> Comparaciones realizadas: {comparaciones} | Eficiencia: O(log n)");
                Console.WriteLine("--------------------------------------------------");
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error: {ex.Message}");
            }
            Pausar();
        }

        private static void EjecutarSalir()
        {
            Console.Write("\n¿Está seguro que desea salir del sistema? (S/N): ");
            string? resp = Console.ReadLine()?.Trim().ToUpper();
            if (resp == "S")
            {
                Console.WriteLine("\nCerrando DataCore v4.0. ¡Hasta pronto!");
            }
        }

        private static void MostrarMensajeError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR]: {mensaje}");
            Console.ResetColor();
        }

        private static void Pausar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}