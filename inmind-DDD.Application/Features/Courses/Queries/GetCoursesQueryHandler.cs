using AutoMapper;
using inmind_DDD.Application.ViewModels;
using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Application.Features.Courses.Queries;

public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseViewModel>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetCoursesQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseViewModel>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await _context.Courses.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<CourseViewModel>>(courses);
    }
}