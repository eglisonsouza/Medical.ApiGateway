using Ocelot.DependencyInjection;
using Ocelot.Middleware;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddJsonFile(Path.Combine("config", "ocelot.json"), optional: false, reloadOnChange: true);

        builder.Services.AddOcelot();

        var app = builder.Build();

        app.UseOcelot();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();
    }
}