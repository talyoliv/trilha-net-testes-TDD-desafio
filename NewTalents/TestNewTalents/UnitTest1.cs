using System;
using Xunit;
using NewTalents;

namespace TestNewTalents
{
    public class UnitTest1
    {

        public Calculadora construirClasse()
        {
            string data = "13/05/2024";
            Calculadora calc = new Calculadora(data);

            return calc;
        }

        [Theory]
        [InlineData (1, 2, 3)]
        [InlineData (4, 5, 9)]
        public void TestSomar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Somar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 4)]
        [InlineData(5, 5, 0)]
        public void TestSubtrair(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Subtrair(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TestMultiplicar(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Multiplicar(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TestDividir(int val1, int val2, int resultado)
        {
            Calculadora calc = construirClasse();

            int resultadoCalculadora = calc.Dividir(val1, val2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calc = construirClasse();

            Assert.Throws<DivideByZeroException>(
                () => calc.Dividir(3, 0)
            );
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(10)]
        public void TestarNumerosParesRetornaVerdadeiro(int numero)
        {
            Calculadora calc = construirClasse();

            bool resultado = calc.NumeroPar(numero);

            Assert.True(resultado);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(7)]
        [InlineData(9)]
        [InlineData(11)]
        [InlineData(15)]
        public void TestarNumerosParesRetornaFalso(int numero)
        {
            Calculadora calc = construirClasse();

            bool resultado = calc.NumeroPar(numero);

            Assert.False(resultado);
        }

        [Theory]
        [InlineData(17)]
        [InlineData(19)]
        [InlineData(21)]
        [InlineData(23)]
        [InlineData(25)]
        public void TestarNumerosImparesRetornaVerdadeiro(int numero)
        {
            Calculadora calc = construirClasse();

            bool resultado = calc.NumeroImpar(numero);

            Assert.True(resultado);
        }

        [Theory]
        [InlineData(18)]
        [InlineData(20)]
        [InlineData(22)]
        [InlineData(24)]
        [InlineData(26)]
        public void TestarNumerosImparesRetornaFalso(int numero)
        {
            Calculadora calc = construirClasse();

            bool resultado = calc.NumeroImpar(numero);

            Assert.False(resultado);
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = construirClasse();

            calc.Somar(1, 2);
            calc.Somar(2, 8);
            calc.Somar(3, 7);
            calc.Somar(4, 1);

            var lista = calc.Historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}