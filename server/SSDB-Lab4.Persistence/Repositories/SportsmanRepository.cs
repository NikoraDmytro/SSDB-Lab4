using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Common.DTOs.Sportsman;
using SSDB_Lab4.Common.RequestFeatures;
using SSDB_Lab4.Domain.entities;
using SSDB_Lab4.Persistence.Extensions;

namespace SSDB_Lab4.Persistence.Repositories;

public class SportsmanRepository
    : GenericRepository<Sportsman>, ISportsmanRepository
{
    public SportsmanRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<PagedList<Sportsman>> GetAllPagedAsync(
        SportsmanRequestParameters parameters)
    {
        IQueryable<Sportsman> query;
        
        if (parameters.MinCompetitionCount != null)
        {
            query = Context
                .GetSportsmanCompetitionParticipation(
                    (int) parameters.MinCompetitionCount);
        }
        else
        {
            query = DbSet;
        }
        
        return await query
            .OrderBy(x => x.Id)
            .ToPagedListAsync(
                parameters.PageNumber, 
                parameters.PageSize);
    }

    public async Task<PagedList<Sportsman>>
        GetAvailableSportsmenAsync(
            int competitionId,
            RequestParameters parameters)
    {
        return await DbSet
            .Where(s => s.Competitors.All(
                c => c.CompetitionId != competitionId))
            .ToPagedListAsync(
                parameters.PageNumber,
                parameters.PageSize);
    }
}