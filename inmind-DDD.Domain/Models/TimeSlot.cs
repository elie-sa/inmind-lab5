namespace inmind_DDD.Domain.Models;

public class TimeSlot
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}