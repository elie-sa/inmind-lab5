using AutoMapper;
using inmind_DDD.Application.ViewModels;
using inmind_DDD.Persistence.Services.CourseRepository;
using MediatR;

namespace inmind_DDD.Application.Features.Courses.Queries;

public class GetCourseByIdLocalCachingQueryHandler : IRequestHandler<GetCourseByIdLocalCachingQuery, CourseViewModel>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public GetCourseByIdLocalCachingQueryHandler(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }
    
    public async Task<CourseViewModel> Handle(GetCourseByIdLocalCachingQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseByIdAsync(request.Id);
        return _mapper.Map<CourseViewModel>(course);
    }

}