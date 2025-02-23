using MediatR;

namespace inmind_DDD.Application.Features.Courses.Commands;

public class UpdateMaxStudentsCommand: IRequest<bool>
{
    public int Id { get; set; }
    public int MaxStudents { get; set; }
}