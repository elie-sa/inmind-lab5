using AutoMapper;
using inmind_DDD.Application.ViewModels;
using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Application.Features.TimeSlots.Queries;

public class GetTimeSlotsQueryHandler : IRequestHandler<GetTimeSlotsQuery, IEnumerable<TimeSlotViewModel>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetTimeSlotsQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TimeSlotViewModel>> Handle(GetTimeSlotsQuery request, CancellationToken cancellationToken)
    {
        var timeSlots = _context.TimeSlots;
        return _mapper.Map<IEnumerable<TimeSlotViewModel>>(timeSlots);
    }
}