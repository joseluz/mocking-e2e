using DockerComposeFixture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace MyStore.API.Test
{
    [CollectionDefinition(nameof(WebAppCollection))]
    public class WebAppCollection : ICollectionFixture<CustomWebApplicationFactory>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    public class CustomWebApplicationFactory : WebApplicationFactory<Program>, IDisposable
    {
        private readonly DockerFixture dockerFixture;

        public CustomWebApplicationFactory(IMessageSink messageSink)
        {
            dockerFixture = new DockerFixture(messageSink);
            dockerFixture.InitOnce(() =>
            {
                return new DockerFixtureOptions
                {
                    DockerComposeFiles = new[] { "../../../docker-compose.yaml" },
                    CustomUpTest = lines => lines.Any(l => l.Contains("Mongo import task is complete")),
                    DockerComposeUpArgs = "--build",
                    DockerComposeDownArgs = "--volumes",
                };
            });
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                var integrationConfig = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.Test.json")
                    .Build();

                config.AddConfiguration(integrationConfig);
            });
        }

        protected override void ConfigureClient(HttpClient client)
        {
            base.ConfigureClient(client);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            dockerFixture.Dispose();
        }
    }
}
