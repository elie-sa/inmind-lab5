using inmind_DDD.Application.ViewModels;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Teachers.Queries;

public class GetTeachersQuery : IRequest<IEnumerable<TeacherViewModel>> 
{ }