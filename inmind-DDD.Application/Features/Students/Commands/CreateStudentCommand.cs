using MediatR;

namespace inmind_DDD.Application.Features.Students.Commands;

public class CreateStudentCommand : IRequest<int>
{
    public string Name { get; set; }
    public double GradeAverage { get; set; }
    public bool CanApplyToFrance { get; set; }
}
