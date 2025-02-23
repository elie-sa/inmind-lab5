using inmind_DDD.Application.ViewModels;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Students.Queries;

public class GetStudentByIdQuery : IRequest<StudentViewModel>
{
    public int Id { get; set; }
    public GetStudentByIdQuery(int id) => Id = id;
}
