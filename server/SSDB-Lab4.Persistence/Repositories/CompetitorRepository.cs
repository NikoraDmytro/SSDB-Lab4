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

    public async Task<IEnumerable<Competitor>> GetBySportsmenIds(
        int competitionId, 
        IEnumerable<int> ids)
    {
        return await DbSet
            .Where(c => c.CompetitionId == competitionId)
            .Where(c => ids.Contains(c.SportsmanId))
            .ToListAsync();
    }
}