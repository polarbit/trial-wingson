using System;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using WingsOn.Application.Airlines.Resources;
using Xunit;

namespace WingsOn.Api.IntegrationTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                    webHost.UseStartup<Startup>();
                    // webHost.Configure(app => app.Run(async ctx =>
                    //    await ctx.Response.WriteAsync("Hello World!")));
                });

            // Build and start the IHost
            var host = await hostBuilder.StartAsync();

            var client = host.GetTestClient();

            var httpResponse = await client.GetAsync("/airlines");

            httpResponse.EnsureSuccessStatusCode();

            var airlinesJsonString = await httpResponse.Content.ReadAsStringAsync();
            var airlineResources = JsonSerializer.Deserialize<AirlineResource[]>(airlinesJsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
