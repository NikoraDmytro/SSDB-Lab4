namespace SSDB_Lab4.Abstractions.Persistence;

public interface IUnitOfWork
{
    Task<int> SaveAsync();
    void Dispose();
}