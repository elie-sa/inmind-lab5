using MediatR;

namespace inmind_DDD.Application.Features.Teachers.Commands;

public class CreateTeacherCommand: IRequest<int>
{
    public string Name { get; set; }
}