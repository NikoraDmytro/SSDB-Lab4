using Microsoft.EntityFrameworkCore;
using SSDB_Lab4.Common.RequestFeatures;

namespace SSDB_Lab4.Persistence.Extensions;

public static class QueryableExtensions
{
    public static async Task<PagedList<T>> ToPagedListAsync<T>(
        this IQueryable<T> source,
        int page,
        int pageSize)
    {
        var count = await source.CountAsync();
        
        if (count > 0)
        {
            var items = await source
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            
            return new PagedList<T>(items, count, page, pageSize);
        }

        return new PagedList<T>();
    }
}