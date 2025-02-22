using inmind_DDD.Domain.Models;

namespace inmind_DDD.Persistence.Services.TimeSlotRepository;

public interface ITimeSlotRepository
{
    Task<TimeSlot?> GetTimeSlotByIdAsync(int timeSlotId);
}