using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Courses.Commands;

public class UpdateCourseCommandHandler: IRequestHandler<UpdateCourseCommand, bool>
{
    private readonly IAppDbContext _context;

    public UpdateCourseCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        if (request.MaxStudents <= 0)
        {
            throw new ArgumentException("Max students must be greater than zero.");
        }
        var course = await _context.Courses.FindAsync(request.Id, cancellationToken);
        if (course == null)
        {
            throw new ArgumentException($"Course with id {request.Id} does not exist.");
        }
        
        course.MaxStudents = request.MaxStudents;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}