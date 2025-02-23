namespace inmind_DDD.Application.ViewModels;

public class CourseViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MaxStudents { get; set; }
    public DateTime EnrollmentStart { get; set; }
    public DateTime EnrollmentEnd { get; set; }

    public int? TeacherId { get; set; }
    public string? TeacherName { get; set; }

    public int? TimeSlotId { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
}