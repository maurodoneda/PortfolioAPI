using Microsoft.Extensions.Logging;

namespace DataAccess;

public class BaseRepository : IBaseRepository
{
    private readonly AppDbContext _context;
    private readonly ILoggerFactory _loggerFactory;
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

    protected BaseRepository(AppDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        _loggerFactory = loggerFactory;
    }

    public async Task<T> CreateAsync<T>(T entity) where T : class
    {
        var logger = _loggerFactory.CreateLogger<T>();
        
        logger.LogInformation($"Creating new db entry {typeof(T)}...");
        await _semaphore.WaitAsync();
        try
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<T> ReadAsync<T>(int id) where T : class
    {
        await _semaphore.WaitAsync();
        try
        {
            return await _context.Set<T>().FindAsync(id);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<T> UpdateAsync<T>(T entity) where T : class
    {
        await _semaphore.WaitAsync();
        try
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task DeleteAsync<T>(T entity) where T : class
    {
        await _semaphore.WaitAsync();
        try
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        finally
        {
            _semaphore.Release();
        }
    }
}


