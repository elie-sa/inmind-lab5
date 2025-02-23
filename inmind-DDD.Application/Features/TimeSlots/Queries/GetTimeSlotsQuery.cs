using inmind_DDD.Application.ViewModels;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.TimeSlots.Queries;

public class GetTimeSlotsQuery : IRequest<IEnumerable<TimeSlotViewModel>> { }
