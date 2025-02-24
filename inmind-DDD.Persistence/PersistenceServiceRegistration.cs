using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Persistence.Services;
using inmind_DDD.Persistence.Services.CourseRepository;
using inmind_DDD.Persistence.Services.CourseRepository.LocalCachingCourseRepository;
using inmind_DDD.Persistence.Services.StudentRepository;
using inmind_DDD.Persistence.Services.TeacherRepository;
using inmind_DDD.Persistence.Services.TimeSlotRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace inmind_DDD.Persistence;

public static class PersistenceServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // added the default connection in appsettings.json
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        // adding the service here instead 
        services.AddScoped<IAppDbContext, AppDbContext>();
        
        // adding the repositories responsible to return T by id (whether from cache or db (would set up the value in cache))
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
        
        // adding local caching service
        services.AddScoped<ILocalCachingCourseRepository, LocalCachingCourseRepository>();
    }

}
