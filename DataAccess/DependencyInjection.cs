using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        Log.Information("Adding application...");
        services
            .AddDbContext<AppDbContext>(ServiceLifetime.Transient)
            .AddScoped<Func<AppDbContext>>(p => p.GetRequiredService<AppDbContext>);

        services.AddScoped<IBaseRepository, BaseRepository>();

        return services;
    }
}