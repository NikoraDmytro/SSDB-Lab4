using Microsoft.EntityFrameworkCore;
using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Common.RequestFeatures;
using SSDB_Lab4.Domain.entities;
using SSDB_Lab4.Persistence.Extensions;

namespace SSDB_Lab4.Persistence.Repositories;

public abstract class GenericRepository<T>: IGenericRepository<T> 
    where T : BaseEntity
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<T> DbSet;

    protected GenericRepository(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<PagedList<T>> GetAllPagedAsync(
        RequestParameters parameters)
    {
        return await DbSet
            .OrderBy(x => x.Id)
            .ToPagedListAsync(
                parameters.PageNumber, 
                parameters.PageSize);
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<List<T>> GetByIdsAsync(IEnumerable<int> ids)
    {
        return await DbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
    }

    public virtual async Task AddAsync(T entity)
    {
        await Context.AddAsync(entity);
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await Context.AddRangeAsync(entities);
    }

    public virtual void Update(T entity)
    {
        Context.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        Context.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}