using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Courses.Queries;

public class GetCourseByIdQuery : IRequest<Course>
{
    public int Id { get; set; }
    public GetCourseByIdQuery(int id) => Id = id;
}