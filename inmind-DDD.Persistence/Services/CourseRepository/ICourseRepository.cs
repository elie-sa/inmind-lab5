using inmind_DDD.Domain.Models;

namespace inmind_DDD.Persistence.Services.CourseRepository;

public interface ICourseRepository
{
    Task<Course?> GetCourseByIdAsync(int courseId);

}