using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.Repositories;

public class SportsmanRepository
    : GenericRepository<Sportsman>, ISportsmanRepository
{
    public SportsmanRepository(AppDbContext context) : base(context)
    {
    }
}