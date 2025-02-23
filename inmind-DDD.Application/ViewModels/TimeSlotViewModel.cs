namespace inmind_DDD.Application.ViewModels;

public class TimeSlotViewModel
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    
    public int TeacherId { get; set; }
    public string TeacherName { get; set; } = string.Empty;

    public int? CourseId { get; set; }
    public string? CourseName { get; set; }
}