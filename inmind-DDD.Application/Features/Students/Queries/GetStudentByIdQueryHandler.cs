using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;

namespace inmind_DDD.Application.Features.Students.Queries;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
{
    private readonly IAppDbContext _context;

    public GetStudentByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _context.Students.FindAsync(request.Id, cancellationToken);
        if (student == null)
        {
            throw new KeyNotFoundException($"Student with ID {request.Id} not found.");
        }
        return student;
    }
}
