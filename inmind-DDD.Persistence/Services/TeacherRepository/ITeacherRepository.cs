using inmind_DDD.Domain.Models;

namespace inmind_DDD.Persistence.Services.TeacherRepository;

public interface ITeacherRepository
{
    Task<Teacher?> GetTeacherByIdAsync(int teacherId);
}