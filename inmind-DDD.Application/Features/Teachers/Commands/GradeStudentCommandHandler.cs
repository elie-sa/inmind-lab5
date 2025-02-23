using inmind_DDD.Application.Services.Features.Teachers.Commands;
using inmind_DDD.Contracts.Interfaces;
using MediatR;

namespace inmind_DDD.Application.Features.Teachers.Commands;

public class GradeStudentCommandHandler: IRequestHandler<GradeStudentCommand, double>
{
    private readonly IAppDbContext _context;

    public GradeStudentCommandHandler(IAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<double> Handle(GradeStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _context.Students.FindAsync(request.StudentId, cancellationToken);
        if (student == null)
        {
            throw new ArgumentException($"Student with id {request.StudentId} does not exist.");
        }

        if (request.Grade <= 0 || request.Grade > 20)
        {
            throw new ArgumentException($"Grade {request.Grade} is invalid.");
        }

        if (student.TotalNumberOfGrades == 0)
        {
            student.TotalNumberOfGrades = 1;
            student.GradeAverage = request.Grade;
        }
        else
        {
            student.GradeAverage = ((student.GradeAverage*student.TotalNumberOfGrades)+request.Grade)/(student.TotalNumberOfGrades+1);
            student.TotalNumberOfGrades++;
        }
        
        student.CanApplyToFrance = request.Grade >= 15? true : false;
        await _context.SaveChangesAsync(cancellationToken);

        return student.GradeAverage;
    }
}