using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Courses.Commands;

public class UpdateCourseHandler: IRequestHandler<UpdateCourseCommand, bool>
{
    private readonly IAppDbContext _context;

    public UpdateCourseHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _context.Courses.FindAsync(request.Id);
        if (course == null) return false;

        course.Name = request.Name;
        course.MaxStudents = request.MaxStudents;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}