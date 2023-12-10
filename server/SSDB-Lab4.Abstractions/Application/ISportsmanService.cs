using SSDB_Lab4.Common.DTOs.Sportsman;
using SSDB_Lab4.Common.RequestFeatures;

namespace SSDB_Lab4.Abstractions.Application;

public interface ISportsmanService
{
    Task<PagedList<SportsmanDto>> GetSportsmenAsync(
        SportsmanRequestParameters parameters);
    Task<SportsmanDto?> GetSportsmanByIdAsync(int id);
    Task<SportsmanDto> CreateSportsmanAsync(
        CreateSportsmanDto createSportsmanDto);
    Task UpdateSportsmanAsync(
        int id, 
        UpdateSportsmanDto updateSportsmanDto);
    Task DeleteSportsmanAsync(int id);
}