using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Application.Features.TimeSlots.Queries;

public class GetTimeSlotsQueryHandler : IRequestHandler<GetTimeSlotsQuery, IQueryable<TimeSlot>>
{
    private readonly IAppDbContext _context;

    public GetTimeSlotsQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<TimeSlot>> Handle(GetTimeSlotsQuery request, CancellationToken cancellationToken)
    {
        return _context.TimeSlots.Include(ts => ts.Teacher).Include(ts => ts.Course).AsQueryable();
    }
}