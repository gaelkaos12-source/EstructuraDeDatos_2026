# DataCore v4.0 - Fase 4: Integración Definitiva, Búsqueda Binaria Indexada y Menú Maestro (CLI)

**Proyecto:** DataCore v4.0  
**Fase:** 4 (Entrega Final)  
**Módulos:** Búsqueda Binaria Indexada $O(\log n)$, Menú Maestro Interactivo CLI, Análisis Teórico de Algoritmos y Control de Versiones.

---

## 1. Módulo 1: Búsqueda Binaria Indexada ($O(\log n)$)

### 1.1 Explicación Algorítmica y Lógica
1. **Extracción e Indexación ($O(n \log n)$):** Dado que la estructura de datos primaria es una Lista Enlazada Simple (que carece de acceso aleatorio directo), se extraen los nodos activos hacia un arreglo auxiliar contiguo en memoria.
2. **Ordenamiento Previo:** El arreglo generado se ordena por el atributo clave (`Id`) en orden ascendente mediante algoritmos de alto rendimiento (`QuickSort` / `MergeSort`).
3. **Búsqueda Logarítmica:** Mediante punteros de límites (`izquierda`, `derecha`) y la selección del punto medio (`medio = izquierda + (derecha - izquierda) / 2`), el espacio de búsqueda se reduce a la mitad en cada iteración.
4. **Métrica de Rendimiento:** La función contabiliza internamente cada comparación efectuada, retornando tanto el registro hallado como el total de iteraciones/comparaciones requeridas.

### 1.2 Implementación C# (`BusquedaIndexada.cs`)

```csharp
using System;

namespace DataCore
{
    /// <summary>
    /// Estructura base para los registros procesados en el sistema DataCore.
    /// </summary>
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

    /// <summary>
    /// Proporciona funcionalidades avanzadas de búsqueda y gestión de índices.
    /// </summary>
    public static class BusquedaIndexada
    {
        /// <summary>
        /// Ejecuta una Búsqueda Binaria sobre un arreglo ordenado de registros.
        /// Complejidad Temporal: O(log n)
        /// Complejidad Espacial: O(1)
        /// </summary>
        /// <param name="arreglo">Arreglo unidimensional ordenado previamente por Id.</param>
        /// <param name="idBuscado">Identificador entero a localizar.</param>
        /// <returns>
        /// Tupla conteniendo:
        /// - Registro: El objeto hallado o null si no existe.
        /// - Comparaciones: Entero con la cantidad exacta de evaluaciones realizadas.
        /// </returns>
        public static (RegistroDatos? Registro, int Comparaciones) BuscarRegistroIndexado(RegistroDatos[] arreglo, int idBuscado)
        {
            // Manejo de caso borde: Arreglo nulo o vacío
            if (arreglo == null || arreglo.Length == 0)
            {
                return (null, 0);
            }

            int izquierda = 0;
            int derecha = arreglo.Length - 1;
            int comparaciones = 0;

            while (izquierda <= derecha)
            {
                int medio = izquierda + (derecha - izquierda) / 2;
                comparaciones++;

                // Prevención ante celdas no inicializadas
                if (arreglo[medio] == null)
                {
                    derecha = medio - 1;
                    continue;
                }

                if (arreglo[medio].Id == idBuscado)
                {
                    return (arreglo[medio], comparaciones); // Elemento encontrado
                }

                if (arreglo[medio].Id < idBuscado)
                {
                    izquierda = medio + 1; // Descarte de la mitad izquierda
                }
                else
                {
                    derecha = medio - 1; // Descarte de la mitad derecha
                }
            }

            // Elemento no localizado tras agotar el rango
            return (null, comparaciones);
        }
    }
}