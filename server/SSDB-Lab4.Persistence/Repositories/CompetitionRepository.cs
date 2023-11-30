using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.Repositories;

public class CompetitionRepository
    : GenericRepository<Competition>, ICompetitionRepository
{
    public CompetitionRepository(AppDbContext context) : base(context)
    {
    }
}