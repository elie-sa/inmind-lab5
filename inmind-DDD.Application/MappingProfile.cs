using AutoMapper;
using inmind_DDD.Application.ViewModels;
using inmind_DDD.Domain.Models;

namespace inmind_DDD.Application;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Teacher, TeacherViewModel>();
        CreateMap<Student, StudentViewModel>();
        CreateMap<Course, CourseViewModel>();
        CreateMap<TimeSlot, TimeSlotViewModel>();
    }
}