using inmind_DDD.Domain.Models;

namespace inmind_DDD.Persistence.Services;

public interface ICourseRepository
{
    Task<Course?> GetCourseByIdAsync(int courseId);

}