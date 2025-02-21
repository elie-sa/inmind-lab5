using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Application.Services;
using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

public static class ApplicationServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {  
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            
        services.AddScoped<IAppDbContext, AppDbContext>();
    }
}