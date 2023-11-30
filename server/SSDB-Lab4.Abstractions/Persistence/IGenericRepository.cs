using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Abstractions.Persistence;

public interface IGenericRepository<T> where T: BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetByIdsAsync(IEnumerable<int> ids);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void Delete(T entity);
}