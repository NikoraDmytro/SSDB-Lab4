using SSDB_Lab4.Common.DTOs.Competitors;
using SSDB_Lab4.Common.RequestFeatures;

namespace SSDB_Lab4.Abstractions.Application;

public interface ICompetitorService
{
    Task<PagedList<CompetitorDto>> GetCompetitorsAsync(
        int competitionId,
        RequestParameters parameters);
    Task<CompetitorDto?> GetCompetitorByIdAsync(int id);
    Task CreateCompetitorsCollectionAsync(
        int competitionId,
        IEnumerable<CreateCompetitorDto> createCompetitorDtos);
    Task DeleteCompetitorAsync(int id);
    Task UpdateCompetitorAsync(
        int id, 
        UpdateCompetitorLapDto updateCompetitorLapDto);
    Task UpdateCompetitorAsync(
        int id, 
        UpdateCompetitorWeightDto updateCompetitorWeightDto);
}