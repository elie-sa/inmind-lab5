using MediatR;

namespace inmind_DDD.Application.Services.Features.Teachers.Commands;

public class GradeStudentCommand: IRequest<double>
{
    public int StudentId { get; set; }
    public double Grade { get; set; }
}