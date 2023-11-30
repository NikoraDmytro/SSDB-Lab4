using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Persistence.Repositories;

namespace SSDB_Lab4.Persistence;

public static class DependencyRegistrar
{
    public static void ConfigurePersistenceLayerDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.ConfigureDbContext(configuration);
        services.ConfigureRepositories();
        services.ConfigureUnitOfWork();
    }

    private static void ConfigureDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("SqlConnection");
            
            options.UseSqlServer(connectionString);
        });
    }
    
    private static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISportsmanRepository, SportsmanRepository>();
        services.AddScoped<ICompetitionRepository, CompetitionRepository>();
        services.AddScoped<IDivisionRepository, DivisionRepository>();
        services.AddScoped<ICompetitorRepository, CompetitorRepository>();
    }
    
    private static void ConfigureUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}