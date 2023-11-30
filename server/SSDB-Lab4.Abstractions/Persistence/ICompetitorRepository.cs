using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Abstractions.Persistence;

public interface ICompetitorRepository: IGenericRepository<Competitor>
{
    public Task<List<TReturn>> GetAllMappedAsync<TReturn>(
        int competitionId,
        Func<IQueryable<Competitor>, IQueryable<TReturn>> map);
    
    public Task<TReturn?> GetByIdMappedAsync<TReturn>(
        int competitionId,
        Func<IQueryable<Competitor>, IQueryable<TReturn>> map);

    public Task<IEnumerable<Competitor>> GetBySportsmenIds(
        int competitionId,
        IEnumerable<int> ids);
}