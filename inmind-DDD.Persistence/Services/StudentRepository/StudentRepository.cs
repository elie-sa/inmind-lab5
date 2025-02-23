using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace inmind_DDD.Persistence.Services.StudentRepository;

public class StudentRepository: BaseCacheRepository<Student>, IStudentRepository
{
    public StudentRepository(IAppDbContext context, IDistributedCache cache)
        : base(context, cache) { }

    public async Task<Student?> GetStudentByIdAsync(int studentId)
    {
        return await GetByIdAsync(studentId, dbSet => dbSet.Include(s => s.Courses));
    }
}