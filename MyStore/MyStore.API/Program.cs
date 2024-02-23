using FreeMarket.Integration;
using MongoDB.Driver;
using MyStore.Application.Connectors;
using MyStore.Application.Repositories;
using MyStore.Application.Services;
using MyStore.Persistence;
using MyStore.Persistence.DataStore;
using System.Security.Authentication;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        // services
        services.AddScoped<IProductService, ProductService>();

        //repositories
        services.AddScoped<IProductRepository, ProductRepository>();

        // datastores 
        services.AddScoped<IProductDataStore, ProductDataStore>();

        //connectors
        services.AddScoped<IFreeMarketConnector, FreeMarketConnector>();
        var baseUrl = builder.Configuration["FreeMarketUrl"] ?? throw new ArgumentException("Missing FreeMarket service url");
        services.AddHttpClient<IFreeMarketConnector, FreeMarketConnector>((client) =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });

        // Mongo setup
        var connectionString = builder.Configuration["MongoDB:ConnectionString"];
        var databaseName = builder.Configuration["MongoDB:DatabaseName"];

        var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
        settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
        var mongoClient = new MongoClient(settings);
        var mongoDatabase = mongoClient.GetDatabase(databaseName);
        services.AddSingleton(mongoDatabase);

        // OpenApi 3.0
        services.AddOpenApiDocument((document, provider) =>
        {
            document.PostProcess = (document) =>
            {
                document.OpenApi = "3.0.0";
                document.Info.Version = "v1";
                document.Info.Title = "MyStore API";
                document.Info.Description = "MyStore Cool Description";
            };
        });

        var app = builder.Build();
        app.MapGet("/", () => "Hello World!");

        if (app.Environment.IsDevelopment())
        {
            //app.UseSwagger();
            //app.UseSwaggerUI();
        }

        app.MapControllers();
        app.UseDeveloperExceptionPage();
        app.UseOpenApi();
        app.UseSwaggerUi();

        app.Run();
    }
}