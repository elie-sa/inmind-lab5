namespace inmind_DDD.Domain.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MaxStudents { get; set; }
    public DateTime EnrollmentStart { get; set; }
    public DateTime EnrollmentEnd { get; set; }
    public List<Student> Students { get; set; }
    
    public int? TeacherId { get; set; } 
    public Teacher? Teacher { get; set; }

    public int? TimeSlotId { get; set; }
    public TimeSlot? TimeSlot { get; set; }
}