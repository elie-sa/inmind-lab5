using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.TimeSlots.Queries;

public class GetTimeSlotByIdQuery : IRequest<TimeSlot>
{
    public int Id { get; set; }
    public GetTimeSlotByIdQuery(int id) => Id = id;
}
