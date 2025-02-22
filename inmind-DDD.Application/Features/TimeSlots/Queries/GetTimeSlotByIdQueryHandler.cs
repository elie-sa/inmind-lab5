using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using inmind_DDD.Persistence.Services.TimeSlotRepository;
using MediatR;

namespace inmind_DDD.Application.Features.TimeSlots.Queries;

public class GetTimeSlotByIdQueryHandler : IRequestHandler<GetTimeSlotByIdQuery, TimeSlot>
{
    private readonly ITimeSlotRepository _repository;

    public GetTimeSlotByIdQueryHandler(ITimeSlotRepository repository)
    {
        _repository = repository;
    }

    public async Task<TimeSlot> Handle(GetTimeSlotByIdQuery request, CancellationToken cancellationToken)
    {
        var timeSlot = await _repository.GetTimeSlotByIdAsync(request.Id);
        if (timeSlot == null)
        {
            throw new KeyNotFoundException($"TimeSlot with ID {request.Id} not found.");
        }
        return timeSlot;
    }
}
