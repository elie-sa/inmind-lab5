using inmind_DDD.Application.ViewModels;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Courses.Queries;

public class GetCoursesQuery : IRequest<IEnumerable<CourseViewModel>>
{ }