namespace inmind_DDD.Domain.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TimeSlot TimeSlot { get; set; }
    public List<Course> Courses { get; set; }
}