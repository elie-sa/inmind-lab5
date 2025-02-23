using System.Text.Json;
using inmind_DDD.Contracts.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Persistence.Services;

public class BaseCacheRepository<T> where T : class
{
    private readonly IAppDbContext _context;
    private readonly IDistributedCache _cache;
    private const int CacheExpirationMinutes = 30;

    public BaseCacheRepository(IAppDbContext context, IDistributedCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<T?> GetByIdAsync(int id, Func<DbSet<T>, IQueryable<T>> includeFunc = null)
    {
        string cacheKey = $"{typeof(T).Name}_{id}";

        var cachedData = await _cache.GetStringAsync(cacheKey);
        if (cachedData != null)
        {
            return JsonSerializer.Deserialize<T>(cachedData);
        }

        var dbSet = _context.Set<T>();

        var entity = await dbSet.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);

        if (entity != null)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(CacheExpirationMinutes)
            };

            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(entity), cacheOptions);
        }

        return entity;
    }
}
