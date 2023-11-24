using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Persistence.Repositories;

namespace SSDB_Lab4.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private bool _disposed;
    private readonly AppDbContext _context;

    private ISportsmanRepository? _sportsmanRepository;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public ISportsmanRepository SportsmanRepository =>
        _sportsmanRepository ??= new SportsmanRepository(_context);
    
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