using System;

namespace DataCore.Fase2
{
    public readonly struct RegistroDatos
    {
        public int Id { get; }
        public long HashValidacion { get; }
        public int PesoBytes { get; }

        public RegistroDatos(int id, long hashValidacion, int pesoBytes)
        {
            if (pesoBytes <= 0)
            {
                throw new ArgumentException(
                    "Contrato violado: El peso en bytes debe ser estrictamente mayor a 0.", 
                    nameof(pesoBytes)
                );
            }

            Id = id;
            HashValidacion = hashValidacion;
            PesoBytes = pesoBytes;
        }

        public override string ToString()
        {
            return $"[ID: {Id,4}] | Hash: {HashValidacion,20} | Peso: {PesoBytes,5} bytes";
        }
    }

    public static class ClasificadorSelection
    {
        public static (int comparaciones, int intercambios) Ordenar(RegistroDatos[] arreglo)
        {
            if (arreglo == null || arreglo.Length <= 1)
            {
                return (0, 0);
            }

            int comparaciones = 0;
            int intercambios = 0;

            for (int i = 0; i < arreglo.Length - 1; i++)
            {
                int indiceMinimo = i;
                for (int j = i + 1; j < arreglo.Length; j++)
                {
                    comparaciones++;
                    if (arreglo[j].Id < arreglo[indiceMinimo].Id)
                    {
                        indiceMinimo = j;
                    }
                }

                if (indiceMinimo != i)
                {
                    (arreglo[i], arreglo[indiceMinimo]) = (arreglo[indiceMinimo], arreglo[i]);
                    intercambios++;
                }
            }

            return (comparaciones, intercambios);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine(" PROJECT DATACORE - FASE 2: SELECTION SORT");
            Console.WriteLine(" Estudiante: Gael Alberto Gomez Baltazar");
            Console.WriteLine(" Correo: gael.gomez33@my.unitec.edu.mx");
            Console.WriteLine("=================================================\n");

            var rng = new Random();
            var loteRegistros = new RegistroDatos[40];

            try
            {
                for (int i = 0; i < loteRegistros.Length; i++)
                {
                    loteRegistros[i] = new RegistroDatos(
                        id: rng.Next(1, 1001),
                        hashValidacion: rng.NextInt64(1000000000000000, 9999999999999999),
                        pesoBytes: rng.Next(10, 5001)
                    );
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[ERROR EN CONTRATO]: {ex.Message}");
                return;
            }

            Console.WriteLine(">>> ESTADO INICIAL DEL LOTE (DESORDENADO):");
            ImprimirLote(loteRegistros);

            var (comparaciones, intercambios) = ClasificadorSelection.Ordenar(loteRegistros);

            Console.WriteLine("\n>>> ESTADO FINAL DEL LOTE (ORDENADO POR ID):");
            ImprimirLote(loteRegistros);

            Console.WriteLine("\n=================================================");
            Console.WriteLine(" MÉTRICAS DE EJECUCIÓN");
            Console.WriteLine("=================================================");
            Console.WriteLine($" Total de elementos  : {loteRegistros.Length}");
            Console.WriteLine($" Comparaciones (O(n²)): {comparaciones}");
            Console.WriteLine($" Intercambios (O(n))  : {intercambios}");
            Console.WriteLine("=================================================");
        }

        private static void ImprimirLote(RegistroDatos[] lote)
        {
            foreach (var r in lote)
            {
                Console.WriteLine(r);
            }
        }
    }
}