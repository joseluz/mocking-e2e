using MyStore.Application.Services;
using System.Text.Json;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(Configuration);
        services.AddControllers()
                        .AddNewtonsoftJson()
                        .AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                        });

        services.AddMvc().AddMvcOptions(options => options.EnableEndpointRouting = false);

        // services
        services.AddScoped<IProductService, ProductService>();

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

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        app.UseDeveloperExceptionPage();
        //if (env.IsDevelopment())
        //{
        //    app.UseDeveloperExceptionPage();
        //}
        //else
        //{
        //    app.UseHsts();
        //}

        //app.MapGet("/", () => "Hello World!");

        //if (env.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}

        app.UseMvc();
        app.UseOpenApi();
        app.UseSwaggerUi();

    }
}