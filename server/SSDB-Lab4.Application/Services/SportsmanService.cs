using AutoMapper;
using SSDB_Lab4.Abstractions.Application;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Common;
using SSDB_Lab4.Common.DTOs.Sportsman;
using SSDB_Lab4.Common.Exceptions;
using SSDB_Lab4.Common.RequestFeatures;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Application.Services;

public class SportsmanService: BaseService, ISportsmanService
{
    public SportsmanService(IUnitOfWork unitOfWork, IMapper mapper) 
        : base(unitOfWork, mapper)
    {
    }
    
    public async Task<PagedList<SportsmanDto>> GetSportsmenAsync(
        RequestParameters parameters)
    {
        var sportsmen = await UnitOfWork
            .SportsmanRepository
            .GetAllPagedAsync(parameters);
        
        var sportsmenDto = Mapper.Map<PagedList<SportsmanDto>>(sportsmen);
        
        return sportsmenDto;
    }

    public async Task<SportsmanDto?> GetSportsmanByIdAsync(int id)
    {
        var sportsman = await UnitOfWork
            .SportsmanRepository
            .GetByIdAsync(id);

        if (sportsman is null)
        {
            throw new NotFoundException($"Sportsman was not found!");
        }

        var sportsmanDto = Mapper.Map<SportsmanDto>(sportsman);

        return sportsmanDto;
    }

    public async Task<SportsmanDto> CreateSportsmanAsync(CreateSportsmanDto createSportsmanDto)
    {
        var sportsman = Mapper.Map<Sportsman>(createSportsmanDto);

        await UnitOfWork.SportsmanRepository.AddAsync(sportsman);
        await UnitOfWork.SaveAsync();

        var sportsmanDto = Mapper.Map<SportsmanDto>(sportsman);

        return sportsmanDto;
   }

    public async Task UpdateSportsmanAsync(int id, UpdateSportsmanDto updateSportsmanDto)
    {
        var sportsman = await UnitOfWork
            .SportsmanRepository
            .GetByIdAsync(id);

        if (sportsman is null)
        {
            throw new NotFoundException($"Sportsman was not found!");
        }

        sportsman.FirstName = updateSportsmanDto.FirstName;
        sportsman.LastName = updateSportsmanDto.LastName;
        sportsman.BirthDate = DateTime.Parse(updateSportsmanDto.BirthDate!);
        sportsman.Sex = Enum.Parse<Sex>(updateSportsmanDto.Sex!);
        
        
        UnitOfWork.SportsmanRepository.Update(sportsman);
        await UnitOfWork.SaveAsync();
    }

    public async Task DeleteSportsmanAsync(int id)
    {
        var sportsman = await UnitOfWork
            .SportsmanRepository
            .GetByIdAsync(id);

        if (sportsman is null)
        {
            throw new NotFoundException($"Sportsman was not found!");
        }
        
        UnitOfWork.SportsmanRepository.Delete(sportsman);
        await UnitOfWork.SaveAsync();
    }

}