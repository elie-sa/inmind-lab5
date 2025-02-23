using AutoMapper;
using inmind_DDD.Application.ViewModels;
using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Application.Features.Teachers.Queries;

public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, IEnumerable<TeacherViewModel>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetTeachersQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TeacherViewModel>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
    {
         var teachers = _context.Teachers;
         return _mapper.Map<IEnumerable<TeacherViewModel>>(teachers);
    }
}