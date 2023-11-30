using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.Repositories;

public class DivisionRepository 
    : GenericRepository<Division>, IDivisionRepository
{
    public DivisionRepository(AppDbContext context) : base(context)
    {
    }
}