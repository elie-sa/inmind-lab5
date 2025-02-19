namespace inmind_DDD.Domain.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double GradeAverage { get; set; }
    public bool CanApplyToFrance { get; set; }
    public List<Course> Courses { get; set; }
}