using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Log.Information("Adding application...");

        services.AddScoped<UsersService>();
        
        services.AddAutoMapper(config =>
        {
            config.AddProfile<MapperProfiles>();
        });
        
        return services;
    }
}