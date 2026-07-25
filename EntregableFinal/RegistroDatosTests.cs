using System;
using Xunit;
using DataCore.Fase1;

namespace DataCore.Tests
{
    public class RegistroDatosTests
    {
        [Fact]
        public void RegistroDatos_CreacionValida_AsignaPropiedades()
        {
            var registro = new RegistroDatos(100, 123456789, 1024);
            Assert.Equal(100, registro.Id);
            Assert.Equal(123456789, registro.HashValidacion);
            Assert.Equal(1024, registro.PesoBytes);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        [InlineData(-500)]
        public void RegistroDatos_PesoInvalido_LanzaArgumentException(int pesoInvalido)
        {
            Assert.Throws<ArgumentException>(() => new RegistroDatos(1, 100, pesoInvalido));
        }

        [Fact]
        public void SelectionSort_ArregloDesordenado_OrdenaCorrectamente()
        {
            var datos = new[]
            {
                new RegistroDatos(30, 1, 100),
                new RegistroDatos(10, 2, 100),
                new RegistroDatos(20, 3, 100)
            };

            ClasificadorSelection.Ordenar(datos);

            Assert.Equal(10, datos[0].Id);
            Assert.Equal(20, datos[1].Id);
            Assert.Equal(30, datos[2].Id);
        }

        [Fact]
        public void SelectionSort_ArregloVacio_RetornaCero()
        {
            var datos = Array.Empty<RegistroDatos>();
            var (comp, swaps) = ClasificadorSelection.Ordenar(datos);
            Assert.Equal(0, comp);
            Assert.Equal(0, swaps);
        }

        [Fact]
        public void SelectionSort_UnSoloElemento_RetornaCero()
        {
            var datos = new[] { new RegistroDatos(1, 100, 50) };
            var (comp, swaps) = ClasificadorSelection.Ordenar(datos);
            Assert.Equal(0, comp);
            Assert.Equal(0, swaps);
        }

        [Fact]
        public void SelectionSort_ArregloInvertido_VerificaMetricas()
        {
            var datos = new[]
            {
                new RegistroDatos(3, 1, 100),
                new RegistroDatos(2, 2, 100),
                new RegistroDatos(1, 3, 100)
            };

            var (comp, swaps) = ClasificadorSelection.Ordenar(datos);

            Assert.Equal(3, comp);
            Assert.True(swaps > 0);
            Assert.Equal(1, datos[0].Id);
        }
    }
}
