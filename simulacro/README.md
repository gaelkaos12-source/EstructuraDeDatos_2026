# Reporte de Auditoría de Código - Simulacro Bimestral

## 1. Código Base con Errores 

using System;
using System.Collections.Generic;

namespace SimulacroBimestral
{
    
    public class SistemaProcesamiento
    {
        
        public List<string> datosParaProcesar = new List<string>(); 

        public void Ejecutar()
        {
            if (datosParaProcesar.Count == 0) return;

            Console.WriteLine("Procesando datos de manera local...");
            foreach (var dato in datosParaProcesar)
            {
                Console.WriteLine($"Dato procesado: {dato}");
            }
        }
    }

    
    public class ProcesadorRemoto : SistemaProcesamiento
    {
        public string UrlServidor;

       
        public new void Ejecutar()
        {
            Console.WriteLine($"Conectando a {UrlServidor} para procesar remotamente...");
            foreach (var dato in datosParaProcesar)
            {
                Console.WriteLine($"Enviando {dato} al servidor.");
            }
        }
    }
}


2. Análisis Técnico de los Fallos
1. Encapsulamiento Roto
Clase afectada: SistemaProcesamiento (campo datosParaProcesar).

Principio violado: Ocultación de datos / Encapsulamiento.

Gravedad: Alta.

Justificación: Permitir el acceso directo de escritura a datosParaProcesar destruye la integridad del objeto. Los componentes externos pueden alterar la lista saltándose cualquier regla de validación del negocio.

2. Herencia Mal Aplicada
Clase afectada: ProcesadorRemoto.

Principio violado: Principio de Sustitución de Liskov (LSP).

Gravedad: Alta.

Justificación: El mecanismo de herencia se forzó únicamente para reutilizar código. Al verse obligado a usar la palabra clave new para ocultar el método Ejecutar, se quiebra el polimorfismo esperado y se introduce fragilidad en el diseño.

3. Acoplamiento Excesivo
Clase afectada: Estructura general de ejecución.

Principio violado: Principio de Inversión de Dependencias (DIP).

Gravedad: Media.

Justificación: El sistema está amarrado rígidamente a componentes específicos de ejecución local o remota en lugar de depender de contratos abstractos (interfaces), limitando la flexibilidad ante futuros cambios.
