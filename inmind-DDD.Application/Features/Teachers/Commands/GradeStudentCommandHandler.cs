using inmind_DDD.Application.Services.Features.Teachers.Commands;
using inmind_DDD.Persistence;
using MediatR;

namespace inmind_DDD.Application.Features.Teachers.Commands;

public class GradeStudentCommandHandler: IRequestHandler<GradeStudentCommand, double>
{
    private readonly AppDbContext _context;

    public GradeStudentCommandHandler(AppDbContext context)
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

        if (request.Grade <= 0)
        {
            throw new ArgumentException($"Grade {request.Grade} is invalid.");
        }
        
        student.GradeAverage = request.Grade;
        await _context.SaveChangesAsync(cancellationToken);

        return student.GradeAverage;
    }
}