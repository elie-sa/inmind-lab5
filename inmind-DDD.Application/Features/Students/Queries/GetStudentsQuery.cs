using inmind_DDD.Application.ViewModels;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Students.Queries;

public class GetStudentsQuery : IRequest<IEnumerable<StudentViewModel>> { }