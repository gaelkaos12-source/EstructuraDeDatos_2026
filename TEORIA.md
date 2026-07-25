# Sustento Teórico - Fase 1 DataCore
**Estudiante:** Gael Alberto Gomez Baltazar  
**Correo:** gael.gomez33@my.unitec.edu.mx  

## Pregunta 1: Gestión de Memoria (Stack vs. Heap)
Al definir `RegistroDatos` como un `readonly struct` (tipo de valor), las instancias locales y los arreglos de tipo struct se alojan en el **Stack** (o en un bloque contiguo de memoria). 
- **Ventajas:** No genera presión sobre el Garbage Collector (GC), reduciendo pausas de latencia. Su ciclo de vida está atado al marco del método.
- **Contigüidad de Caché:** Al estar alineados en memoria contigua, se mejora el *cache locality* (L1/L2), haciendo que la lectura en arreglos masivos sea extremadamente rápida frente a un arreglo de objetos tipo `class` almacenados dispersos en el Heap.

## Pregunta 2: Eficiencia de Intercambios en Selection Sort
Selection Sort tiene una complejidad temporal de $O(n^2)$ en comparaciones ($\frac{n(n-1)}{2}$ siempre), pero garantiza como máximo **$O(n)$ intercambios en memoria** ($n-1$ swaps como máximo).
- **Comparación con Bubble Sort:** Bubble Sort realiza hasta $O(n^2)$ intercambios en el peor de los casos.
- **Importancia en Hardware:** En memorias Flash, discos SSD o EEPROM donde las operaciones de escritura desgastan físicamente las celdas o son penalizadas en tiempo/energía, minimizar los swaps a nivel lineal $O(n)$ hace a Selection Sort una opción superior sobre otros algoritmos de complejidad cuadrática.
