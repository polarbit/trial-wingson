using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using WingsOn.Application.Airlines.Resources;
using Xunit;

namespace WingsOn.Api.IntegrationTests
{
    public class AirlinesControllerTests
    {
        [Fact]
        public async Task Test_GetAllAirlines()
        {
            // Arrange
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                    webHost.UseStartup<Startup>();
                });

            // Build and start the IHost
            var host = await hostBuilder.StartAsync();
            var client = host.GetTestClient();
            
            // Act
            var httpResponse = await client.GetAsync("/airlines");

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var airlinesJsonString = await httpResponse.Content.ReadAsStringAsync();
            var airlineResources = JsonSerializer.Deserialize<AirlineResource[]>(airlinesJsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            Assert.NotEmpty(airlineResources);
        }
    }
}
