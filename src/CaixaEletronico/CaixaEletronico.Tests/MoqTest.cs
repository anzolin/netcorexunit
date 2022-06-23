using CaixaEletronico.Domain;
using Moq;
using NSubstitute;
using System;
using Xunit;

namespace CaixaEletronico.Tests
{
    public class MoqTest
    {
        [Fact(DisplayName = "Mock saque com sucesso NSubstitute")]
        public void Saque_Com_Sucesso_NSUb()
        {
            // Cria objeto mock
            var caixa = Substitute.For<ICaixa>();
            var valorDoSaque = 50;

            // Efetua simulação de saque e assegura que retorno é int de array
            caixa.Saque(valorDoSaque).Returns(Array.Empty<int>());

            // Confirma que método foi executado uma unica vez
            caixa.Received(1);
        }

        [Fact(DisplayName = "Mock saque com sucesso Moq")]
        public void Saque_Com_Sucesso_Moq()
        {
            // Cria objeto mock
            var caixa = new Mock<ICaixa>();
            var valorDoSaque = 50;

            // Efetua simulação de saque
            caixa.Object.Saque(valorDoSaque);
            
            // Confirma que método foi executado uma unica vez
            caixa.Verify(r => r.Saque(valorDoSaque), Times.Once);
        }
    }
}
