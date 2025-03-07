using inmind_DDD.Application.Features.Courses.Commands;
using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Students.Commands;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateStudentCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Student name is required.");
        }

        if (request.GradeAverage < 0 || request.GradeAverage > 20)
        {
            throw new ArgumentException("Grade average must be between 0 and 20.");
        }
        
        var student = new Student
        {
            Name = request.Name,
            GradeAverage = request.GradeAverage,
            CanApplyToFrance = request.GradeAverage > 15 ? true : false
        };
        
        _context.Students.Add(student);
        
        await _context.SaveChangesAsync(cancellationToken);

        return student.Id;
    }
}
