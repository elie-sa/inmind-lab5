namespace inmind_DDD.Domain.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MaxStudents { get; set; }
    public DateTime EnrollmentStart { get; set; }
    public DateTime EnrollmentEnd { get; set; }
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
}