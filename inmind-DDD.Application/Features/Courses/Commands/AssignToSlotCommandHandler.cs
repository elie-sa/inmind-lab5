using inmind_DDD.Contracts.Interfaces;
using MediatR;

namespace inmind_DDD.Application.Features.Courses.Commands;

public class AssignToSlotCommandHandler : IRequestHandler<AssignToSlotCommand, bool>
{
    private readonly IAppDbContext _context;

    public AssignToSlotCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(AssignToSlotCommand request, CancellationToken cancellationToken)
    {
        var course = await _context.Courses.FindAsync(request.CourseId, cancellationToken);
        if (course == null)
        {
            throw new ArgumentException($"Course with id {request.CourseId} not found.");
        }

        var timeSlot = await _context.TimeSlots.FindAsync(request.TimeSlotId, cancellationToken);
        if (timeSlot == null)
        {
            throw new ArgumentException($"TimeSlot with id {request.TimeSlotId} not found.");
        }

        if (course.Teacher != null)
        {
            throw new ArgumentException($"Course with id {request.CourseId} already has a teacher.");
        }

        course.TimeSlotId = timeSlot.Id;
        course.TimeSlot = timeSlot;
        course.Teacher = timeSlot.Teacher;
        course.TeacherId = timeSlot.TeacherId;
        
        await _context.SaveChangesAsync(cancellationToken);
        return true;

    }
}    