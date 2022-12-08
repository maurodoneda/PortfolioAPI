using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DataAccess;

public class AppDbContext : DbContext
{
    private IConfiguration _configuration;
    private ILogger<AppDbContext> _logger;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration, ILogger<AppDbContext> logger) : base(options)
    {
        _configuration = configuration;
        _logger = logger;
    }
    
    private DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("Postgres");
            
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseNpgsql(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(30), new List<string>());
                });
        }
    }
}