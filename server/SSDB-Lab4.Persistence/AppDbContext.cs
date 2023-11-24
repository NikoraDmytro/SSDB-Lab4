using Microsoft.EntityFrameworkCore;
using SSDB_Lab4.Domain.entities;
using SSDB_Lab4.Persistence.EntityConfiguration;

namespace SSDB_Lab4.Persistence;

public class AppDbContext: DbContext
{
    public AppDbContext()
    {
    }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    private DbSet<Sportsman>? Sportsmen { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(
            typeof(SportsmanEntityConfiguration).Assembly);
    }
}