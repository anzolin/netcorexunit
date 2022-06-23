using CaixaEletronico.Domain;
using System;
using Xunit;

namespace CaixaEletronico.Tests
{
    public class NormalAssertsTest
    {
        private readonly Caixa caixa = new Caixa();

        [Fact]
        public void Saque_Valido()
        {
            var valorDoSaque = 510;
            var saqueEhValido = caixa.ValidaCedulasDisponiveis(valorDoSaque);

            Assert.True(saqueEhValido);
        }

        [Fact]
        public void Deve_Gerar_Excecao()
        {
            var valorDoSaque = 5;

            Assert.Throws<Exception>(() => caixa.Saque(valorDoSaque));
        }
    }
}
