namespace SSDB_Lab4.Abstractions.Persistence;

public interface IUnitOfWork
{
    ISportsmanRepository SportsmanRepository { get; } 
    
    Task<int> SaveAsync();
    void Dispose();
}