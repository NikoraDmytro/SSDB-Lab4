using SSDB_Lab4.Abstractions.Persistence;
using SSDB_Lab4.Persistence.Repositories;

namespace SSDB_Lab4.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private bool _disposed;
    private readonly AppDbContext _context;

    private ISportsmanRepository? _sportsmanRepository;
    private ICompetitionRepository? _competitionRepository;
    private IDivisionRepository? _divisionRepository;
    private ICompetitorRepository? _competitorRepository;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public ISportsmanRepository SportsmanRepository =>
        _sportsmanRepository ??= new SportsmanRepository(_context);

    public ICompetitionRepository CompetitionRepository =>
        _competitionRepository ??= new CompetitionRepository(_context);

    public IDivisionRepository DivisionRepository =>
        _divisionRepository ??= new DivisionRepository(_context);

    public ICompetitorRepository CompetitorRepository =>
        _competitorRepository ??= new CompetitorRepository(_context);

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