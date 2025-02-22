using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Courses.Commands;


public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateCourseCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ArgumentException("Course name cannot be empty.");

        if (request.MaxStudents <= 0)
            throw new ArgumentOutOfRangeException(nameof(request.MaxStudents), "Max students must be greater than zero.");
        
        var course = new Course
        {
            Name = request.Name,
            MaxStudents = request.MaxStudents,
            EnrollmentStart = request.EnrollmentStart,
            EnrollmentEnd = request.EnrollmentEnd
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync(cancellationToken);
        return course.Id;
    }
}