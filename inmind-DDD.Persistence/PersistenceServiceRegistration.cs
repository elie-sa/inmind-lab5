using inmind_DDD.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
    }

}

