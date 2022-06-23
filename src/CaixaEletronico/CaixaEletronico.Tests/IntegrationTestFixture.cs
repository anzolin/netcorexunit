using CaixaEletronico.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace CaixaEletronico.Tests
{
    public class IntegrationTestFixture
    {
        public IntegrationTestFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ICaixa, Caixa>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
