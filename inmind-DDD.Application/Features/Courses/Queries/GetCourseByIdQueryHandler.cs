using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Courses.Queries;

public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
{
    private readonly IAppDbContext _context;

    public GetCourseByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await _context.Courses.FindAsync(request.Id , cancellationToken);
        if (course == null)
        {
            throw new KeyNotFoundException($"Course with ID {request.Id} not found.");
        }
        return course;
    }
}
