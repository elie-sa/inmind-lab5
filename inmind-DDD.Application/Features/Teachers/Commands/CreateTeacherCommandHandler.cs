using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Teachers.Commands;

public class CreateTeacherCommandHandler: IRequestHandler<CreateTeacherCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateTeacherCommandHandler(IAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Teacher name is required.");
        }

        var teacher = new Teacher
        {
            Name = request.Name
        };

        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync(cancellationToken);

        return teacher.Id;
    }
}