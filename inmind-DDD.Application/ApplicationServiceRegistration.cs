using System.Reflection;
using inmind_DDD.Infrastructure;
using inmind_DDD.Infrastructure.Middleware;
using inmind_DDD.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace inmind_DDD.Application;

public static class ApplicationServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {  
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        // these are connections to third party resources (OData & Redis etc) (found in the infrastructure layer)
        services.AddInfrastructureServices(configuration);
        
        // connection to the DbContext found here (found in the persistence layer)
        services.AddPersistenceServices(configuration);
        
        services.AddAutoMapper(typeof(MappingProfile));
    }
    
    public static IApplicationBuilder UseApplicationMiddlewares(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RequestLoggingMiddleware>();
    }
}