using inmind_DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Contracts.Interfaces;

public interface IAppDbContext
{
    DbSet<Student> Students { get; }
    DbSet<Teacher> Teachers { get; }
    DbSet<Course> Courses { get; }
    DbSet<TimeSlot> TimeSlots { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<T> Set<T>() where T : class;
}