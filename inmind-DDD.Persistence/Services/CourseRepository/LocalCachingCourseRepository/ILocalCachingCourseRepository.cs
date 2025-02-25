using inmind_DDD.Domain.Models;

namespace inmind_DDD.Persistence.Services.CourseRepository.LocalCachingCourseRepository;

public interface ILocalCachingCourseRepository
{
    Task<Course?> GetCourseByIdAsync(int courseId);

}