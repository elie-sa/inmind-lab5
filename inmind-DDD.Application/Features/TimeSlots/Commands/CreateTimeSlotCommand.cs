using MediatR;

namespace inmind_DDD.Application.Features.TimeSlots.Commands;

public class CreateTimeSlotCommand : IRequest<int>
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    
    public int TeacherId { get; set; }
}