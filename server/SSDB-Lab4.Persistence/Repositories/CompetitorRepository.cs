using Microsoft.EntityFrameworkCore;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Common.RequestFeatures;
using SSDB_Lab4.Domain.entities;
using SSDB_Lab4.Persistence.Extensions;

namespace SSDB_Lab4.Persistence.Repositories;

public class CompetitorRepository
    : GenericRepository<Competitor>, ICompetitorRepository
{
    public CompetitorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<PagedList<TReturn>> GetAllPagedMappedAsync<TReturn>(
        int competitionId,
        RequestParameters parameters,
        Func<IQueryable<Competitor>, IQueryable<TReturn>> map)
    {
        var query = DbSet.Where(c => c.CompetitionId == competitionId);

        return await map(query).ToPagedListAsync(
            parameters.PageNumber, 
            parameters.PageSize);
    }

    public async Task<TReturn?> GetByIdMappedAsync<TReturn>(
        int id,
        Func<IQueryable<Competitor>, IQueryable<TReturn>> map)
    {
        var query = DbSet.Where(c => c.Id == id);

        return await map(query).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Competitor>> GetBySportsmenIdsAsync(
        int competitionId, 
        IEnumerable<int> ids)
    {
        return await DbSet
            .Where(c => c.CompetitionId == competitionId)
            .Where(c => ids.Contains(c.SportsmanId))
            .ToListAsync();
    }

    public async Task WeightCompetitorAsync(
        int competitorId,
        double weight)
    {
        await Context.Database.ExecuteSqlInterpolatedAsync(
            $"usp_weight_competitor {competitorId}, {weight}"
        );
    }
    
    public async Task<int> CountLessHeavyAsync(double? weight)
    {
        if (weight == null)
        {
            return await DbSet
                .Select(c => 
                    Context.CountLessThanAverageWeight())
                .FirstOrDefaultAsync();
        }

        return await DbSet
            .Select(c =>
                Context.CountLessHeavy((double) weight))
            .FirstOrDefaultAsync();
    }

    public async Task<PagedList<CompetitorLog>> 
        GetCompetitorLogsAsync(
            int competitionId, 
            RequestParameters parameters)
    {
        return await Context.Set<CompetitorLog>()
            .Where(c => 
                c.Competitor!.CompetitionId == competitionId)
            .OrderBy(c => c.Id)
            .ToPagedListAsync(
                parameters.PageNumber, 
                parameters.PageSize);
    }

    public async Task<PagedList<FailedInsertCompetitorLog>> 
        GetFailedInsertCompetitorLogsAsync(
            int competitionId, 
            RequestParameters parameters)
    {
        return await Context.Set<FailedInsertCompetitorLog>()
            .Where(c => 
                c.CompetitionId == competitionId)
            .OrderBy(c => c.Id)
            .ToPagedListAsync(
                parameters.PageNumber, 
                parameters.PageSize);
    }
}