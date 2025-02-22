using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.TimeSlots.Queries;

public class GetTimeSlotByIdQueryHandler : IRequestHandler<GetTimeSlotByIdQuery, TimeSlot>
{
    private readonly IAppDbContext _context;

    public GetTimeSlotByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<TimeSlot> Handle(GetTimeSlotByIdQuery request, CancellationToken cancellationToken)
    {
        var timeSlot = await _context.TimeSlots.FindAsync(request.Id , cancellationToken);
        if (timeSlot == null)
        {
            throw new KeyNotFoundException($"TimeSlot with ID {request.Id} not found.");
        }
        return timeSlot;
    }
}
