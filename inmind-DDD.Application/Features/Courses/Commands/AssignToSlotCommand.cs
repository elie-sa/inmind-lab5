using MediatR;

namespace inmind_DDD.Application.Features.Courses.Commands;

public class AssignToSlotCommand: IRequest<bool>
{
    public int CourseId { get; set; }
    public int TimeSlotId { get; set; }
}