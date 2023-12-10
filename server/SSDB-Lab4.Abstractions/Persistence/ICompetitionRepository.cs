using SSDB_Lab4.Common.DTOs.Competitors;
using SSDB_Lab4.Common.DTOs.Division;
using SSDB_Lab4.Common.RequestFeatures;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Abstractions.Persistence;

public interface ICompetitionRepository: IGenericRepository<Competition>
{
    Task<IEnumerable<Competition>> GetOverlapping(string name, DateTime startDate);

    public Task<IEnumerable<CompetitionDivisionDto>> GetDivisionsAsync(
        int competitionId);

    public Task<IEnumerable<DivisionCompetitorDto>> GetDivisionCompetitorsAsync(
        int competitionId,
        int divisionId);

    public Task<Competition?> GetLargestCompetitionAsync();
    
    public Task<string?> GetLargestDivisionAsync(int id);
    
    public Task<PagedList<CompetitionCopy>> 
        GetCompetitionCopiesAsync(
            RequestParameters parameters);
}