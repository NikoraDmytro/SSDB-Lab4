using SSDB_Lab4.Common.DTOs.Sportsman;

namespace SSDB_Lab4.Abstractions.Application;

public interface ISportsmanService
{
    Task<IEnumerable<SportsmanDto>> GetSportsmenAsync();
    Task<SportsmanDto?> GetSportsmanByIdAsync(int id);
    Task<SportsmanDto> CreateSportsmanAsync(CreateSportsmanDto createSportsmanDto);
    Task UpdateSportsmanAsync(int id, UpdateSportsmanDto updateSportsmanDto);
    Task DeleteSportsmanAsync(int id);
}