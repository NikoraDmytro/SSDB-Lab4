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
    private DbSet<Competition>? Competitions { get; set; }
    private DbSet<Division>? Divisions { get; set; }
    private DbSet<Competitor>? Competitors { get; set; }
    private DbSet<CompetitorLog>? CompetitorLogs { get; set; }
    private DbSet<CompetitionCopy>? CompetitionCopies { get; set; }
    private DbSet<FailedInsertCompetitorLog>? FailedInsertCompetitorLogs { get; set; }

    public int CountLessThanAverageWeight()
        => throw new NotSupportedException();

    public int CountLessHeavy(double weight)
        => throw new NotSupportedException();

    public string GetLargestDivisionName(int competitionId)
        => throw new NotSupportedException();
    
    public int GetLargestCompetition()
        => throw new NotSupportedException();
    
    public IQueryable<Sportsman> 
        GetSportsmanCompetitionParticipation(int participationCount) 
        => FromExpression(() => 
            GetSportsmanCompetitionParticipation(participationCount));
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
            .HasDbFunction(
                typeof(AppDbContext).GetMethod(
                    nameof(CountLessThanAverageWeight))!
                )
            .HasName("fn_lessThanAverage");
        
        builder
            .HasDbFunction(
                typeof(AppDbContext).GetMethod(
                    nameof(CountLessHeavy),
                    new [] { typeof(double) }
                    )!
                )
            .HasName("fn_countCompetitors");
            
        builder
            .HasDbFunction(
                typeof(AppDbContext).GetMethod(
                    nameof(GetLargestDivisionName),
                    new [] { typeof(int) }
                    )!
            )
            .HasName("fn_biggestDivision");
        
        builder
            .HasDbFunction(
                typeof(AppDbContext).GetMethod(
                    nameof(GetLargestCompetition))!
            )
            .HasName("fn_largestCompetition");
        
        builder
            .HasDbFunction(
                typeof(AppDbContext).GetMethod(
                    nameof(GetSportsmanCompetitionParticipation),
                    new [] { typeof(int) }
                    )!
            )
            .HasName("fn_competitors");

        builder.ApplyConfigurationsFromAssembly(
            typeof(SportsmanEntityConfiguration).Assembly);
    }
}