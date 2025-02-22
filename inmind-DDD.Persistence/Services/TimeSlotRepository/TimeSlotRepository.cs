using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace inmind_DDD.Persistence.Services.TimeSlotRepository;

public class TimeSlotRepository : BaseCacheRepository<TimeSlot>, ITimeSlotRepository
{
    public TimeSlotRepository(IAppDbContext context, IDistributedCache cache)
        : base(context, cache) { }

    public async Task<TimeSlot?> GetTimeSlotByIdAsync(int timeSlotId)
    {
        return await GetByIdAsync(timeSlotId);
    }
}