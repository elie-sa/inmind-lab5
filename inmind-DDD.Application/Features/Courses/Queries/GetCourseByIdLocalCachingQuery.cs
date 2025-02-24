using inmind_DDD.Application.ViewModels;
using MediatR;

namespace inmind_DDD.Application.Features.Courses.Queries;

public class GetCourseByIdLocalCachingQuery : IRequest<CourseViewModel>
{
    public int Id { get; }
    public GetCourseByIdLocalCachingQuery(int id) => Id = id;
}