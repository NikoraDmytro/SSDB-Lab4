using SSDB_Lab4.Common.DTOs.Division;

namespace SSDB_Lab4.Abstractions.Application;

public interface IDivisionService
{
    Task<IEnumerable<DivisionDto>> GetDivisionsAsync();
    Task<DivisionDto?> GetDivisionByIdAsync(int id);
    Task<DivisionDto> CreateDivisionAsync(CreateDivisionDto createDivisionDto);
    Task UpdateDivisionAsync(int id, UpdateDivisionDto updateDivisionDto);
    Task DeleteDivisionAsync(int id);
}