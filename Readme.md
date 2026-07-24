# Entregable 15: Algoritmos de Búsqueda de Alto Rendimiento
**Estudiante:** Gael  
**Asignatura:** Estructura de Datos  

---

## 1. Análisis Comparativo de Complejidad Asintótica

El software diseñado implementa y contrasta las dos metodologías de búsqueda fundamentales sobre colecciones de datos unidimensionales en memoria:

### A. Búsqueda Lineal o Secuencial
* **Complejidad Peor Caso:** $O(n)$
* **Comportamiento:** Incrementa el número de comparaciones de forma directamente proporcional al tamaño de la colección. Si el elemento está en la última posición o no existe, requerirá recorrer la totalidad de la estructura ($n$ pasos).
* **Ventaja:** No requiere que la información esté preordenada y demuestra alta localidad de memoria en arreglos pequeños.

### B. Búsqueda Binaria (Divide y Vencerás)
* **Complejidad Peor Caso:** $O(\log n)$
* **Comportamiento:** Divide de forma sistemática el espacio de búsqueda al 50% en cada iteración. Para un universo de $10,000$ registros, el peor escenario posible se resuelve en un máximo de $\approx 14$ iteraciones ($\log_2(10000) \approx 13.28$).
* **Requisito Crítico:** Requiere obligatoriamente que la colección de datos se encuentre ordenada de manera ascendente previo a la ejecución.

---

## 2. Matriz de Rendimiento Observada

| Métrica de Eficiencia | Búsqueda Lineal $O(n)$ | Búsqueda Binaria $O(\log n)$ |
| :--- | :--- | :--- |
| **Conjunto de Datos** | 10,000 Elementos | 10,000 Elementos |
| **Iteraciones Requeridas** | Depende de la posición (~9,282 en peor caso) | **Máximo 14 pasos** |
| **Estado del Arreglo** | Ordenado o Desordenado | **Obligatoriamente Ordenado** |
| **Estrategia** | Recorrido Secuencial | División de espacio (Punto Medio) |