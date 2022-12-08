using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Log.Information("Adding application...");

        services.AddSingleton<UserService>();
        
        services.AddAutoMapper(config =>
        {
            config.AddProfile<MapperProfiles>();
        });
        
        return services;
    }
}