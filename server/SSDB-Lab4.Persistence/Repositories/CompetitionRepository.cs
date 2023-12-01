using Microsoft.EntityFrameworkCore;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Common.DTOs.Competitors;
using SSDB_Lab4.Common.DTOs.Division;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.Repositories;

public class CompetitionRepository
    : GenericRepository<Competition>, ICompetitionRepository
{
    public CompetitionRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Competition>> GetOverlapping(string name, DateTime startDate)
    {
        return await DbSet
            .Where(c => c.Name == name)
            .Where(c => (c.StartDate - startDate).TotalDays < 30)
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
}