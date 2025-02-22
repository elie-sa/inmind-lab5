using System.Text.Json;
using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace inmind_DDD.Persistence.Services;

public class CourseRepository : BaseCacheRepository<Course>, ICourseRepository
{
    public CourseRepository(IAppDbContext context, IDistributedCache cache)
        : base(context, cache) { }

    public async Task<Course?> GetCourseByIdAsync(int courseId)
    {
        return await GetByIdAsync(courseId, dbSet => dbSet.Include(c => c.Students));
    }
}              