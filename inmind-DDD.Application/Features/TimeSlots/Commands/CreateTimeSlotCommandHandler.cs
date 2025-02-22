using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.TimeSlots.Commands;


public class CreateTimeSlotCommandHandler : IRequestHandler<CreateTimeSlotCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateTimeSlotCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTimeSlotCommand request, CancellationToken cancellationToken)
    {
        if (request.EndTime <= request.StartTime)
        {
            throw new ArgumentException("End time must be greater than start time.");
        }
        
        var teacher = _context.Teachers.Find(request.TeacherId);

        if (teacher == null)
        {
            throw new ArgumentException("Teacher not found.");
        }

        var timeSlot = new TimeSlot
        {
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            TeacherId = request.TeacherId,
        };

        _context.TimeSlots.Add(timeSlot);

        await _context.SaveChangesAsync(cancellationToken);
        return timeSlot.Id;
    }
}
