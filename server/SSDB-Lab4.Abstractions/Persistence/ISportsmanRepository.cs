using SSDB_Lab4.Common.RequestFeatures;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Abstractions.Persistence;

public interface ISportsmanRepository: IGenericRepository<Sportsman>
{
    public Task<PagedList<Sportsman>> 
        GetAvailableSportsmenAsync(
            int competitionId,
            RequestParameters parameters);
}