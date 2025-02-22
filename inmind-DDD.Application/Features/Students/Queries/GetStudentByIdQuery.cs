using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Students.Queries;

public class GetStudentByIdQuery : IRequest<Student>
{
    public int Id { get; set; }
    public GetStudentByIdQuery(int id) => Id = id;
}
