using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace CaixaEletronico.IntegrationTests
{
    public class FixturesTest
    {
        [Theory(DisplayName = "Efetua Saque via api")]
        [InlineData(80)]
        [InlineData(300)]
        [InlineData(500)]
        public async Task Efetua_Saque_Via_Api(int valorSaque)
        {
            await using var application = new TestApplication();
            using var client = application.CreateClient();

            var request = await client.PostAsJsonAsync($"/saque/{valorSaque}", new { });
            var response = await request.Content.ReadAsStringAsync();

            Assert.True(request.IsSuccessStatusCode);
            Assert.Contains("Receba seu saque", response);
        }

        [Theory(DisplayName = "Não Efetua Saque via api")]
        [InlineData(5)]
        [InlineData(15)]
        [InlineData(38)]
        public async Task Nao_Efetua_Saque_Via_Api(int valorSaque)
        {
            await using var application = new TestApplication();
            using var client = application.CreateClient();

            var request = await client.PostAsJsonAsync($"/saque/{valorSaque}", new { });
            var response = await request.Content.ReadAsStringAsync();

            Assert.False(request.IsSuccessStatusCode);
            Assert.Contains("Valor não válido para saque", response);
            Assert.Equal(HttpStatusCode.BadRequest, request.StatusCode);
        }
    }
}
