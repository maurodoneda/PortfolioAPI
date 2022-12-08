using Application;
using DataAccess;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        Log.Logger.Information("Configuring services...");
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDataAccess();
        services.AddApplication();
        
        return services;
    }
    
    public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
    {
        // Use Serilog
        builder.Host.UseSerilog((hostContext, services, configuration) =>
        {
            configuration
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .Enrich.WithThreadName()
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName()
                .WriteTo.File("logs/portolioApp.txt", rollingInterval: RollingInterval.Day, outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level:u3}] [{ThreadId}] [{SourceContext}] - {Message} {NewLine}{Exception}")
                .WriteTo.Console(theme: AnsiConsoleTheme.Code, outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level:u3}] [{ThreadId}] [{SourceContext}] - {Message} {NewLine}{Exception}");
        });

        return builder;
    }
}