using AutoMapper;
using SSDB_Lab4.Abstractions.Application;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Common.DTOs.Competition;
using SSDB_Lab4.Common.Exceptions;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Application.Services;

public class CompetitionService: BaseService, ICompetitionService
{
    public CompetitionService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
    }
    
    public async Task<IEnumerable<CompetitionDto>> GetCompetitionsAsync() 
    {
        var competitions = await UnitOfWork
            .CompetitionRepository
            .GetAllAsync();

        var competitionsDto = Mapper.Map<IEnumerable<CompetitionDto>>(competitions);

        return competitionsDto;
    }

    public async Task<CompetitionDto?> GetCompetitionByIdAsync(int id)
    {
        var competition = await UnitOfWork
            .CompetitionRepository
            .GetByIdAsync(id);

        if (competition is null)
        {
            throw new NotFoundException($"Competition was not found!");
        }

        var competitionDto = Mapper.Map<CompetitionDto>(competition);

        return competitionDto;
    }

    public async Task<CompetitionDto> CreateCompetitionAsync(CreateCompetitionDto createCompetitionDto)
    {
        var competition = Mapper.Map<Competition>(createCompetitionDto);

        await UnitOfWork.CompetitionRepository.AddAsync(competition);
        await UnitOfWork.SaveAsync();

        var competitionDto = Mapper.Map<CompetitionDto>(competition);

        return competitionDto;
    }

    public async Task UpdateCompetitionAsync(int id, UpdateCompetitionDto updateCompetitionDto)
    {
        var competition = await UnitOfWork
            .CompetitionRepository
            .GetByIdAsync(id);

        if (competition is null)
        {
            throw new NotFoundException($"Competition was not found!");
        }

        competition.Name = updateCompetitionDto.Name;
        competition.StartDate = DateTime.Parse(updateCompetitionDto.StartDate!);
        competition.Duration = updateCompetitionDto.Duration;
        competition.City = updateCompetitionDto.City;

        UnitOfWork.CompetitionRepository.Update(competition);
        await UnitOfWork.SaveAsync();
    }

    public async Task DeleteCompetitionAsync(int id)
    { 
        var competition = await UnitOfWork
            .CompetitionRepository
            .GetByIdAsync(id);

        if (competition is null)
        {
            throw new NotFoundException($"Competition was not found!");
        }

        UnitOfWork.CompetitionRepository.Delete(competition);
        await UnitOfWork.SaveAsync();
    }
}