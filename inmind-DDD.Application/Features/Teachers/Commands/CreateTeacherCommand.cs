using MediatR;

namespace inmind_DDD.Application.Services.Features.Teachers.Commands;

public class CreateTeacherCommand: IRequest<int>
{
    public string Name { get; set; }
}