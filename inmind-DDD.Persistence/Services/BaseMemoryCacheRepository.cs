using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using inmind_DDD.Contracts.Interfaces;

public class BaseMemoryCacheRepository<T> where T : class
{
    private readonly IAppDbContext _context;
    private readonly IMemoryCache _cache;
    private const int CacheExpirationMinutes = 30;

    public BaseMemoryCacheRepository(IAppDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<T?> GetByIdAsync(int id, Func<DbSet<T>, IQueryable<T>> includeFunc = null)
    {
        string cacheKey = $"{typeof(T).Name}_{id}";

        if (_cache.TryGetValue(cacheKey, out T cachedData))
        {
            return cachedData;
        }

        var dbSet = _context.Set<T>();

        var entity = await dbSet.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);

        if (entity != null)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(CacheExpirationMinutes)
            };

            _cache.Set(cacheKey, entity, cacheEntryOptions);
        }

        return entity;
    }
}