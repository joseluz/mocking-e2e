//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore;

//public class Program
//{
//    private static void Main(string[] args)
//    {
//        CreateWebHostBuilder(args)
//            .Build()
//            .Run();
//    }

//    private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
//        WebHost.CreateDefaultBuilder(args)
//               .UseStartup<Startup>();
//}

public class Program
{
    private static void Main(string[] args)
    {



        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        //builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.MapGet("/", () => "Hello World!");

        if (app.Environment.IsDevelopment())
        {
            //app.UseSwagger();
            //app.UseSwaggerUI();
        }

        app.MapControllers();

        app.Run();
    }
}