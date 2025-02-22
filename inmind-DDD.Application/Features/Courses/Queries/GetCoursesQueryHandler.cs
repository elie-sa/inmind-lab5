using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Application.Features.Courses.Queries;

public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IQueryable<Course>>
{
    private readonly IAppDbContext _context;

    public GetCoursesQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        return _context.Courses;
    }
}