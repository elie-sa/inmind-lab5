using inmind_DDD.Domain.Models;

namespace inmind_DDD.Persistence.Services.StudentRepository;

public interface IStudentRepository
{
    Task<Student?> GetStudentByIdAsync(int studentId);
}