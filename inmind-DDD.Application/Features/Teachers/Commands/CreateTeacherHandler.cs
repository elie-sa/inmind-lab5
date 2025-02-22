using inmind_DDD.Domain.Models;
using inmind_DDD.Persistence;
using MediatR;

namespace inmind_DDD.Application.Services.Features.Teachers.Commands;

public class CreateTeacherHandler: IRequestHandler<CreateTeacherCommand, int>
{
    private readonly AppDbContext _context;

    public CreateTeacherHandler(AppDbContext context)
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