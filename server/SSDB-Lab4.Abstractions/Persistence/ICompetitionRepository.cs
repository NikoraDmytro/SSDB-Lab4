using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Abstractions.Persistence;

public interface ICompetitionRepository: IGenericRepository<Competition>
{
    Task<IEnumerable<Competition>> GetOverlapping(string name, DateTime startDate);
}