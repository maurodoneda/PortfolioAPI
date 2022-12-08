using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        // Register the MyDbContext class as a dependency.
        services.AddDbContext<AppDbContext>();
        
        return services;
    }
}