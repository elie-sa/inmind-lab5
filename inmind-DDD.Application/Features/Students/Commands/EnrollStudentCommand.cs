using MediatR;

namespace inmind_DDD.Application.Features.Students.Commands;

public class EnrollStudentCommand : IRequest<bool>
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }
}