using SSDB_Lab4.Common.DTOs.Competition;

namespace SSDB_Lab4.Abstractions.Application;

public interface ICompetitionService
{
    Task<IEnumerable<CompetitionDto>> GetCompetitionsAsync();
    Task<CompetitionDto?> GetCompetitionByIdAsync(int id);
    Task<CompetitionDto> CreateCompetitionAsync(CreateCompetitionDto createCompetitionDto);
    Task UpdateCompetitionAsync(int id, UpdateCompetitionDto updateCompetitionDto);
    Task DeleteCompetitionAsync(int id);
}