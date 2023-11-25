using AutoMapper;
using SSDB_Lab4.Abstractions.Application;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Common;
using SSDB_Lab4.Common.DTOs.Sportsman;
using SSDB_Lab4.Common.Exceptions;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Application.Services;

public class SportsmanService: ISportsmanService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public SportsmanService(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<SportsmanDto>> GetSportsmenAsync()
    {
        var sportsmen = await _unitOfWork
            .SportsmanRepository
            .GetAllAsync();
        
        var sportsmenDto = _mapper.Map<IEnumerable<SportsmanDto>>(sportsmen);
        
        return sportsmenDto;
    }

    public async Task<SportsmanDto?> GetSportsmanByIdAsync(int id)
    {
        var sportsman = await _unitOfWork
            .SportsmanRepository
            .GetByIdAsync(id);

        if (sportsman is null)
        {
            throw new NotFoundException($"Sportsman was not found!");
        }

        var sportsmanDto = _mapper.Map<SportsmanDto>(sportsman);

        return sportsmanDto;
    }

    public async Task<SportsmanDto> CreateSportsmanAsync(CreateSportsmanDto createSportsmanDto)
    {
        var sportsman = _mapper.Map<Sportsman>(createSportsmanDto);

        await _unitOfWork.SportsmanRepository.AddAsync(sportsman);
        await _unitOfWork.SaveAsync();

        var sportsmanDto = _mapper.Map<SportsmanDto>(sportsman);

        return sportsmanDto;
    }

    public async Task UpdateSportsmanAsync(int id, UpdateSportsmanDto updateSportsmanDto)
    {
        var sportsman = await _unitOfWork
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
        
        
        _unitOfWork.SportsmanRepository.Update(sportsman);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteSportsmanAsync(int id)
    {
        var sportsman = await _unitOfWork
            .SportsmanRepository
            .GetByIdAsync(id);

        if (sportsman is null)
        {
            throw new NotFoundException($"Sportsman was not found!");
        }
        
        _unitOfWork.SportsmanRepository.Delete(sportsman);
        await _unitOfWork.SaveAsync();
    }
}