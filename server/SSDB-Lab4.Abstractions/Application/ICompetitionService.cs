using SSDB_Lab4.Common.DTOs.Competition;
using SSDB_Lab4.Common.RequestFeatures;

namespace SSDB_Lab4.Abstractions.Application;

public interface ICompetitionService
{
    Task<PagedList<CompetitionDto>> GetCompetitionsAsync(
        RequestParameters parameters);
    Task<CompetitionDto?> GetCompetitionByIdAsync(int id);
    Task<CompetitionDto> CreateCompetitionAsync(
        CreateCompetitionDto createCompetitionDto);
    Task UpdateCompetitionAsync(
        int id, 
        UpdateCompetitionDto updateCompetitionDto);
    Task DeleteCompetitionAsync(int id);
}