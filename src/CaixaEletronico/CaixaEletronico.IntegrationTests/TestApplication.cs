using CaixaEletronico.Domain;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CaixaEletronico.IntegrationTests
{
    public class TestApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<ICaixa, Caixa>();
            });

            return base.CreateHost(builder);
        }
    }
}
