using AutoMapper;
using inmind_DDD.Application.ViewModels;
using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Application.Features.Students.Queries;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<StudentViewModel>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetStudentsQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentViewModel>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = _context.Students;
        return _mapper.Map<IEnumerable<StudentViewModel>>(students);
    }
}