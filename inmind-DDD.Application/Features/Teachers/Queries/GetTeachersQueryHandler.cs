using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Application.Features.Teachers.Queries;

public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, IQueryable<Teacher>>
{
    private readonly IAppDbContext _context;

    public GetTeachersQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Teacher>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
    {
        return _context.Teachers;
    }
}