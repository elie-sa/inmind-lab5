using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace inmind_DDD.Persistence.Services.CourseRepository.LocalCachingCourseRepository;

public class LocalCachingCourseRepository : BaseMemoryCacheRepository<Course>, ILocalCachingCourseRepository
{
    public LocalCachingCourseRepository(IAppDbContext context, IMemoryCache cache)
        : base(context, cache) { }

    public async Task<Course?> GetCourseByIdAsync(int courseId)
    {
        return await GetByIdAsync(courseId, dbSet => dbSet.Include(c => c.Students));
    }
}              