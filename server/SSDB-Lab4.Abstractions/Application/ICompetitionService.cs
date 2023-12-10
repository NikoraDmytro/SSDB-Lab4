using SSDB_Lab4.Common.DTOs.Competition;
using SSDB_Lab4.Common.DTOs.Competitors;
using SSDB_Lab4.Common.DTOs.Division;
using SSDB_Lab4.Common.DTOs.Sportsman;
using SSDB_Lab4.Common.RequestFeatures;
using SSDB_Lab4.Domain.entities;

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
    Task<IEnumerable<CompetitionDivisionDto>> GetDivisionsAsync(int id);
    Task<IEnumerable<DivisionCompetitorDto>> GetDivisionCompetitorsAsync(
        int id, 
        int divisionId);
    Task<PagedList<SportsmanDto>> GetAvailableSportsmenAsync(
        int id,
        RequestParameters parameters);
    public Task<CompetitionDto?> GetLargestCompetitionAsync();
    public Task<string?> GetLargestDivisionAsync(int id);
    
    public Task<PagedList<CompetitionCopy>> 
        GetCompetitionCopiesAsync(
            RequestParameters parameters);
}