using Microsoft.EntityFrameworkCore;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.Repositories;

public class CompetitorRepository
    : GenericRepository<Competitor>, ICompetitorRepository
{
    public CompetitorRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<List<TReturn>> GetAllMappedAsync<TReturn>(
        int competitionId,
        Func<IQueryable<Competitor>, IQueryable<TReturn>> map)
    {
        var query = DbSet.Where(c => c.CompetitionId == competitionId);

        return await map(query).ToListAsync();
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