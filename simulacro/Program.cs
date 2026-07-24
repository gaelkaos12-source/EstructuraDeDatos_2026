using System;
using System.Collections.Generic;

namespace SimulacroBimestral
{
   
    public interface IProcesadorEstrategia
    {
        void Procesar(IEnumerable<string> datos);
    }

    
    public class ProcesamientoLocal : IProcesadorEstrategia
    {
        public void Procesar(IEnumerable<string> datos)
        {
            Console.WriteLine("Procesando datos de manera local...");
            foreach (var dato in datos)
            {
                Console.WriteLine($"Dato procesado localmente: {dato}");
            }
        }
    }

   
    public class ProcesamientoRemoto : IProcesadorEstrategia
    {
        private readonly string _urlServidor;

        public ProcesamientoRemoto(string urlServidor)
        {
            _urlServidor = urlServidor ?? throw new ArgumentNullException(nameof(urlServidor));
        }

        public void Procesar(IEnumerable<string> datos)
        {
            Console.WriteLine($"Conectando a {_urlServidor} para procesar remotamente...");
            foreach (var dato in datos)
            {
                Console.WriteLine($"Enviando {dato} de forma segura al servidor.");
            }
        }
    }

   
    public class GestorProcesamiento
    {
        private readonly List<string> _datos = new List<string>();
        private readonly IProcesadorEstrategia _estrategia;

        
        public IReadOnlyCollection<string> Datos => _datos.AsReadOnly();

        public GestorProcesamiento(IProcesadorEstrategia estrategia)
        {
            _estrategia = estrategia ?? throw new ArgumentNullException(nameof(estrategia));
        }

        public void RegistrarDato(string dato)
        {
            if (string.IsNullOrWhiteSpace(dato))
                throw new ArgumentException("El dato no puede estar vacío.", nameof(dato));

            _datos.Add(dato);
        }

        public void Iniciar()
        {
            if (_datos.Count == 0) return;
            _estrategia.Procesar(_datos);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SIMULACRO BIMESTRAL: ARQUITECTURA CORREGIDA ===");
            Console.WriteLine("Autor: Gael");
            Console.WriteLine($"Fecha: {DateTime.Now:dd/MM/yyyy}\n");

            
            IProcesadorEstrategia estrategiaLocal = new ProcesamientoLocal();
            GestorProcesamiento gestorLocal = new GestorProcesamiento(estrategiaLocal);
            gestorLocal.RegistrarDato("Pedido_001");
            gestorLocal.RegistrarDato("Pedido_002");
            gestorLocal.Iniciar();

            Console.WriteLine();

       
            IProcesadorEstrategia estrategiaRemota = new ProcesamientoRemoto("https://api.empresa.com");
            GestorProcesamiento gestorRemoto = new GestorProcesamiento(estrategiaRemota);
            gestorRemoto.RegistrarDato("Pedido_Remoto_001");
            gestorRemoto.Iniciar();
        }
    }
}
