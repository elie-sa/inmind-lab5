using MediatR;

namespace inmind_DDD.Application.Features.Courses.Commands;

public class UpdateCourseCommand: IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MaxStudents { get; set; }
}