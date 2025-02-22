using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Application.Features.Students.Queries;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IQueryable<Student>>
{
    private readonly IAppDbContext _context;

    public GetStudentsQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        return _context.Students;
    }
}