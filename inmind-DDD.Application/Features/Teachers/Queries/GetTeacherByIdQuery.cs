using inmind_DDD.Application.ViewModels;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Teachers.Queries;

public class GetTeacherByIdQuery: IRequest<TeacherViewModel>
{
    public int Id { get; set; }
    public GetTeacherByIdQuery(int id) => Id = id;
}