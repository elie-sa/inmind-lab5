using System.Reflection;
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
        // added the default connection in appsettings.json
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            
        // adding the service here instead 
        services.AddScoped<IAppDbContext, AppDbContext>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}