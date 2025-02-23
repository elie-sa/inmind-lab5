using AutoMapper;
using inmind_DDD.Application.ViewModels;
using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using inmind_DDD.Persistence.Services.TeacherRepository;
using MediatR;

namespace inmind_DDD.Application.Features.Teachers.Queries;

public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherViewModel>
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IMapper _mapper;

    public GetTeacherByIdQueryHandler(ITeacherRepository teacherRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }

    public async Task<TeacherViewModel> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _teacherRepository.GetTeacherByIdAsync(request.Id);
        if (teacher == null)
        {
            throw new KeyNotFoundException($"Teacher with ID {request.Id} not found.");
        }
        return _mapper.Map<TeacherViewModel>(teacher);
    }
}
