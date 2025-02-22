using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using inmind_DDD.Persistence.Services.StudentRepository;
using MediatR;

namespace inmind_DDD.Application.Features.Students.Queries;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetStudentByIdAsync(request.Id);
        if (student == null)
        {
            throw new KeyNotFoundException($"Student with ID {request.Id} not found.");
        }
        return student;
    }
}
