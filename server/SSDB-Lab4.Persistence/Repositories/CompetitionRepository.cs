using Microsoft.EntityFrameworkCore;
using SSDB_Lab4.Abstractions.Persistence;
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
}