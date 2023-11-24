using Microsoft.EntityFrameworkCore;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.Repositories;

public class GenericRepository<T>: IGenericRepository<T> 
    where T : BaseEntity
{
    private readonly AppDbContext _context;
    protected readonly DbSet<T> DbSet;

    protected GenericRepository(AppDbContext context)
    {
        _context = context;
        DbSet = context.Set<T>();
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }
    
    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task AddAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public virtual void Update(T entity)
    {
        _context.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}