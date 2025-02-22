using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace inmind_DDD.Persistence.Services.TeacherRepository;

public class TeacherRepository : BaseCacheRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(IAppDbContext context, IDistributedCache cache)
        : base(context, cache) { }

    public async Task<Teacher?> GetTeacherByIdAsync(int teacherId)
    {
        return await GetByIdAsync(teacherId, dbSet => dbSet);
    }
}