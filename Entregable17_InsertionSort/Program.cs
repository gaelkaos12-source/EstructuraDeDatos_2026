using System;

namespace Entregable17_InsertionSort
{
    // Fase 3 (Parte A): Estructura de Datos Transaccion
    struct Transaccion
    {
        public int Id;          // Identificador único
        public double Monto;     // Importe en moneda local
        public long Timestamp;   // Marca de tiempo en ms (epoch)

        public Transaccion(int id, double monto, long timestamp)
        {
            Id = id;
            Monto = monto;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return $"ID: {Id,4} | Monto: {Monto,10:F2} | Timestamp: {Timestamp}";
        }
    }

    class Program
    {
        // Fase 3 (Parte B): Módulo de Insertion Sort
        static int OrdenarPorInsercion(Transaccion[] arr)
        {
            int contadorDesplazamientos = 0;
            int n = arr.Length;

            // El subarreglo arr[0] ya se considera ordenado (empieza en i = 1)
            for (int i = 1; i < n; i++)
            {
                Transaccion clave = arr[i];
                int j = i - 1;

                // Desplaza los elementos con un ID mayor al de la clave hacia la derecha
                while (j >= 0 && arr[j].Id > clave.Id)
                {
                    arr[j + 1] = arr[j];
                    contadorDesplazamientos++;
                    j--;
                }

                // Inserta la clave en el espacio libre en j + 1
                arr[j + 1] = clave;
            }

            return contadorDesplazamientos;
        }

        // Fase 3 (Parte C): Módulo Main y Pruebas
        static void Main(string[] args)
        {
            try
            {
                // Arreglo con capacidad para 50 transacciones
                Transaccion[] bitacora = new Transaccion[50];
                Random rng = new Random();

                // Primeros 45 elementos: IDs ordenados ascendentemente (simula datos normales)
                for (int i = 0; i < 45; i++)
                {
                    bitacora[i] = new Transaccion(
                        id: i + 1,
                        monto: Math.Round(rng.NextDouble() * (9999.99 - 0.01) + 0.01, 2),
                        timestamp: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + (i * 100)
                    );
                }

                // Últimos 5 elementos: IDs desordenados (simula registros tardíos/correcciones)
                int[] idsAleatorios = { 78, 3, 99, 12, 55 };
                for (int i = 0; i < 5; i++)
                {
                    bitacora[45 + i] = new Transaccion(
                        id: idsAleatorios[i],
                        monto: Math.Round(rng.NextDouble() * (9999.99 - 0.01) + 0.01, 2),
                        timestamp: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + ((45 + i) * 100)
                    );
                }

                Console.WriteLine("=== OPTIMIZADOR DE BITÁCORAS DE TRANSACCIONES ===\n");

                // Ejecución e instrumentación
                int totalDesplazamientos = OrdenarPorInsercion(bitacora);

                Console.WriteLine("Transacciones ordenadas por ID:");
                foreach (var t in bitacora)
                {
                    Console.WriteLine(t);
                }

                // Cálculo de métricas
                Console.WriteLine($"\nTotal de desplazamientos realizados: {totalDesplazamientos}");
                
                // Peor caso teórico para n = 50: (n * (n - 1)) / 2 = (50 * 49) / 2 = 1225
                double peorCaso = (50.0 * 49.0) / 2.0;
                double eficiencia = (1.0 - ((double)totalDesplazamientos / peorCaso)) * 100.0;
                
                Console.WriteLine($"Eficiencia: {eficiencia:F1}% mejor que el peor caso");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"[ERROR] Desbordamiento de datos: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[ERROR] Formato de entrada inválido: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Excepción inesperada: {ex.Message}");
            }
        }
    }
}
