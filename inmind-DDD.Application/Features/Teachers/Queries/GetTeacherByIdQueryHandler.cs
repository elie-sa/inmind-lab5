using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Teachers.Queries;

public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, Teacher>
{
    private readonly IAppDbContext _context;

    public GetTeacherByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Teacher> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _context.Teachers.FindAsync(request.Id, cancellationToken);
        if (teacher == null)
        {
            throw new KeyNotFoundException($"Teacher with ID {request.Id} not found.");
        }
        return teacher;
    }
}
