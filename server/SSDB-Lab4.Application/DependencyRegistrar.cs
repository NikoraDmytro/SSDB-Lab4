using Microsoft.Extensions.DependencyInjection;
using SSDB_Lab4.Abstractions.Application;
using SSDB_Lab4.Application.MappingProfiles;
using SSDB_Lab4.Application.Services;

namespace SSDB_Lab4.Application;

public static class DependencyRegistrar
{
    public static void ConfigureApplicationLayerDependencies(
        this IServiceCollection services)
    {
        services.ConfigureServices();
        services.ConfigureAutomapper();
    }
    
    private static void ConfigureServices(this IServiceCollection services){
    {
        services.AddScoped<ISportsmanService, SportsmanService>();
    }}
    
    private static void ConfigureAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(SportsmanMappingProfile).Assembly);
    }
}