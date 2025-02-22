namespace inmind_DDD.Domain.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<TimeSlot> TimeSlots { get; set; }
    public List<Course> Courses { get; set; }
    
    public string ProfilePicture { get; set; }
}