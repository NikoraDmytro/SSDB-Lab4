using SSDB_Lab4.Abstractions.Persistence;

namespace SSDB_Lab4.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private bool _disposed;
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
            
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}