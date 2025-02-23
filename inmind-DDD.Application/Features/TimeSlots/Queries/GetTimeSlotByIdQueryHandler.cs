using AutoMapper;
using inmind_DDD.Application.ViewModels;
using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using inmind_DDD.Persistence.Services.TimeSlotRepository;
using MediatR;

namespace inmind_DDD.Application.Features.TimeSlots.Queries;

public class GetTimeSlotByIdQueryHandler : IRequestHandler<GetTimeSlotByIdQuery, TimeSlotViewModel>
{
    private readonly ITimeSlotRepository _repository;
    private readonly IMapper _mapper;

    public GetTimeSlotByIdQueryHandler(ITimeSlotRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TimeSlotViewModel> Handle(GetTimeSlotByIdQuery request, CancellationToken cancellationToken)
    {
        var timeSlot = await _repository.GetTimeSlotByIdAsync(request.Id);
        if (timeSlot == null)
        {
            throw new KeyNotFoundException($"TimeSlot with ID {request.Id} not found.");
        }
        return _mapper.Map<TimeSlotViewModel>(timeSlot);
    }
}
