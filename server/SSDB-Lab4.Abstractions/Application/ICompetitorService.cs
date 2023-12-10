using SSDB_Lab4.Common.DTOs.Competitors;
using SSDB_Lab4.Common.RequestFeatures;
using SSDB_Lab4.Domain.entities;

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
    public Task<int> CountLessHeavyAsync(double? weight);
    public Task<PagedList<CompetitorLog>> GetCompetitorLogsAsync(
        int competitionId,
        RequestParameters parameters);

    public Task<PagedList<FailedInsertCompetitorLog>>
        GetFailedInsertCompetitorLogsAsync(
            int competitionId,
            RequestParameters parameters);
}