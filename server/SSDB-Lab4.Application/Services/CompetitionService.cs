using AutoMapper;
using SSDB_Lab4.Abstractions.Application;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Common.DTOs.Competition;
using SSDB_Lab4.Common.DTOs.Competitors;
using SSDB_Lab4.Common.DTOs.Division;
using SSDB_Lab4.Common.DTOs.Sportsman;
using SSDB_Lab4.Common.Exceptions;
using SSDB_Lab4.Common.RequestFeatures;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Application.Services;

public class CompetitionService: BaseService, ICompetitionService
{
    public CompetitionService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
    }

    private async Task ThrowIfOverlapsAsync(int id, String name, DateTime startDate)
    {
        var overlappingCompetitions = await UnitOfWork
            .CompetitionRepository
            .GetOverlapping(id, name, startDate);
        var overlappingCompetitionsArr = overlappingCompetitions
            .ToArray();

        if (overlappingCompetitionsArr.Length != 0)
        {
            throw new BadRequestException($"The same competition can't be held more than once every 30 days!");
        }

    }
    
    public async Task<PagedList<CompetitionDto>> GetCompetitionsAsync(
        RequestParameters parameters) 
    {
        var competitions = await UnitOfWork
            .CompetitionRepository
            .GetAllPagedAsync(parameters);

        var competitionsDto = Mapper.Map<PagedList<CompetitionDto>>(competitions);

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
        await ThrowIfOverlapsAsync(
            -1,
            createCompetitionDto.Name!, 
            DateTime.Parse(createCompetitionDto.StartDate!));
        
        var competition = Mapper.Map<Competition>(createCompetitionDto);

        await UnitOfWork.CompetitionRepository.AddAsync(competition);
        await UnitOfWork.SaveAsync();

        var competitionDto = Mapper.Map<CompetitionDto>(competition);

        return competitionDto;
    }

    public async Task UpdateCompetitionAsync(int id, UpdateCompetitionDto updateCompetitionDto)
    {
        await ThrowIfOverlapsAsync(
            id,
            updateCompetitionDto.Name!, 
            DateTime.Parse(updateCompetitionDto.StartDate!));
        
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

    public async Task<IEnumerable<CompetitionDivisionDto>> 
        GetDivisionsAsync(int id)
    {
        var competition = await UnitOfWork
            .CompetitionRepository
            .GetByIdAsync(id);

        if (competition is null)
        {
            throw new NotFoundException($"Competition was not found!");
        }

        var divisions = await UnitOfWork
            .CompetitionRepository
            .GetDivisionsAsync(id);

        return divisions;
    }

    public async Task<IEnumerable<DivisionCompetitorDto>> 
        GetDivisionCompetitorsAsync(int id, int divisionId)
    {
        var competition = await UnitOfWork
            .CompetitionRepository
            .GetByIdAsync(id);

        if (competition is null)
        {
            throw new NotFoundException($"Competition was not found!");
        }

        var division = await UnitOfWork
            .DivisionRepository
            .GetByIdAsync(divisionId);
        
        if (division is null)
        {
            throw new NotFoundException($"Division was not found!");
        }

        var competitors = await UnitOfWork
            .CompetitionRepository
            .GetDivisionCompetitorsAsync(id, divisionId);

        return competitors;
    }

    public async Task<PagedList<SportsmanDto>> 
        GetAvailableSportsmenAsync(
            int id, 
            RequestParameters parameters)
    {
        var competition = await UnitOfWork
            .CompetitionRepository
            .GetByIdAsync(id);

        if (competition is null)
        {
            throw new NotFoundException($"Competition was not found!");
        }

        var sportsmen = await UnitOfWork
            .SportsmanRepository
            .GetAvailableSportsmenAsync(id, parameters);
        
        var sportsmenDto = Mapper.Map<PagedList<SportsmanDto>>(sportsmen);

        return sportsmenDto;
    }

    public async Task<CompetitionDto?> GetLargestCompetitionAsync()
    {
        var competition = await UnitOfWork
            .CompetitionRepository
            .GetLargestCompetitionAsync();
        
        var competitionDto = Mapper.Map<CompetitionDto>(competition);

        return competitionDto;
    }

    public async Task<string?> GetLargestDivisionAsync(int id)
    {
        var competition = await UnitOfWork
            .CompetitionRepository
            .GetByIdAsync(id);

        if (competition is null)
        {
            throw new NotFoundException($"Competition was not found!");
        }

        return await UnitOfWork
            .CompetitionRepository
            .GetLargestDivisionAsync(id);
    }

    public async Task<PagedList<CompetitionCopy>> 
        GetCompetitionCopiesAsync(
            RequestParameters parameters)
    {
        var competitionCopies = await UnitOfWork
            .CompetitionRepository
            .GetCompetitionCopiesAsync(parameters);
        
        return competitionCopies;
    }
}