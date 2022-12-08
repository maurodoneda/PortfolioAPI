using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        Log.Information("Adding application...");
        services.AddDbContext<AppDbContext>();
        
        return services;
    }
}