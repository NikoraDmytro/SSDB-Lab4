using Microsoft.EntityFrameworkCore;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Common.DTOs.Competitors;
using SSDB_Lab4.Common.DTOs.Division;
using SSDB_Lab4.Common.RequestFeatures;
using SSDB_Lab4.Domain.entities;
using SSDB_Lab4.Persistence.Extensions;

namespace SSDB_Lab4.Persistence.Repositories;

public class CompetitionRepository
    : GenericRepository<Competition>, ICompetitionRepository
{
    public CompetitionRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task AddAsync(Competition competition)
    {
        await Context.Database.ExecuteSqlInterpolatedAsync(
            @$"usp_insert_competitions 
            @name = {competition.Name}, 
            @start_date = {competition.StartDate}, 
            @duration = {competition.Duration}, 
            @city = {competition.City}"
        );
    }

    public async Task<IEnumerable<Competition>> GetOverlapping(string name, DateTime startDate)
    {
        return await DbSet
            .Where(c => c.Name == name)
            .Where(c => EF.Functions.DateDiffDay(c.StartDate, startDate) < 30)
            .ToListAsync();
    }

    public async Task<IEnumerable<CompetitionDivisionDto>> 
        GetDivisionsAsync(int id)
    {
        var divisions = await DbSet
            .Where(c => c.Id == id)
            .SelectMany(
                c => c.Competitors, 
                (competition, competitor) => competitor.Division)
            .Where(d => d != null)
            .Select(d => new CompetitionDivisionDto()
            {
                Id = d!.Id,
                Name = d.Name,
            })
            .Distinct()
            .ToListAsync();

        return divisions!;
    }

    public async Task<IEnumerable<DivisionCompetitorDto>> 
        GetDivisionCompetitorsAsync(int id, int divisionId)
    {
        var competitors = await DbSet
            .Where(c => c.Id == id)
            .SelectMany(
                c => c.Competitors,
                (competition, competitor) => competitor)
            .Where(c => c.DivisionId == divisionId)
            .Select(c => new DivisionCompetitorDto()
            {
                Id = c.Id,
                FullName = string.Join(
                    " ",
                    c.Sportsman!.LastName, 
                    c.Sportsman!.FirstName),
                LapNum = c.LapNum,
            })
            .ToListAsync();

        return competitors;
    }

    public async Task<Competition?> GetLargestCompetitionAsync()
    {
        return await DbSet
            .Select(c => c)
            .Where(c => 
                c.Id == Context.GetLargestCompetition())
            .FirstOrDefaultAsync();
    }

    public async Task<string?> GetLargestDivisionAsync(int id)
    {
        return await DbSet
            .Select(d => 
                Context.GetLargestDivisionName(id))
            .FirstOrDefaultAsync();
    }

    public async Task<PagedList<CompetitionCopy>> 
        GetCompetitionCopiesAsync(
            RequestParameters parameters)
    {
        return await Context.Set<CompetitionCopy>()
            .OrderBy(c => c.Id)
            .ToPagedListAsync(
                parameters.PageNumber, 
                parameters.PageSize);
    }
}