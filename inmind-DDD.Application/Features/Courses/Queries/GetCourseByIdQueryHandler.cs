using AutoMapper;
using inmind_DDD.Application.ViewModels;
using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using inmind_DDD.Persistence;
using inmind_DDD.Persistence.Services;
using inmind_DDD.Persistence.Services.CourseRepository;
using MediatR;

namespace inmind_DDD.Application.Features.Courses.Queries;

public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseViewModel>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public GetCourseByIdQueryHandler(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<CourseViewModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseByIdAsync(request.Id);
        if (course == null)
        {
            throw new KeyNotFoundException($"Course with ID {request.Id} not found.");
        }
        
        return _mapper.Map<CourseViewModel>(course);
    }
}
