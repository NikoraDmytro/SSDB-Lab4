namespace SSDB_Lab4.Abstractions.Persistence;

public interface IUnitOfWork
{
    ISportsmanRepository SportsmanRepository { get; } 
    ICompetitionRepository CompetitionRepository { get; } 
    IDivisionRepository DivisionRepository { get; } 
    ICompetitorRepository CompetitorRepository { get; } 
    
    Task<int> SaveAsync();
    void Dispose();
}