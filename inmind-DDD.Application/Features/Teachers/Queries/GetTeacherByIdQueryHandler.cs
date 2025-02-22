using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using inmind_DDD.Persistence.Services.TeacherRepository;
using MediatR;

namespace inmind_DDD.Application.Features.Teachers.Queries;

public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, Teacher>
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeacherByIdQueryHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<Teacher> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetTeacherByIdAsync(request.Id);
        if (teacher == null)
        {
            throw new KeyNotFoundException($"Teacher with ID {request.Id} not found.");
        }
        return teacher;
    }
}
