using MyStore.Application.Services;

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
        //services.AddScoped<IProductRepository, ProductRepository>();
        services.AddOpenApiDocument(document =>
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