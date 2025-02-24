using Hangfire;
using Hangfire.PostgreSql;
using inmind_DDD.Infrastructure.BackgroundJobs;
using inmind_DDD.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using StackExchange.Redis;

namespace inmind_DDD.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConnectionString = configuration.GetConnectionString("RedisConnection");
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));

        // Add Redis caching services
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnectionString;
            options.InstanceName = "RedisCacheInstance";
        });
        
        services.AddApiVersioning(options =>
        {
            // setting the default version if not specified (i will not specify a version for most)
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);

            options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");

            // lets us see the available api versions
            options.ReportApiVersions = true;
        });
        
        //adding local caching
        services.AddMemoryCache();
        
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddSerilog(dispose: true);
        });
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // adding hangfire
        services.AddScoped<BackgroundJobService>();
        services.AddHangfire(x => x.UsePostgreSqlStorage(connectionString));
        services.AddHangfireServer();

        services.AddHangfireServer(options => 
        {
            RecurringJob.AddOrUpdate(
                "hourly-job", 
                () => services.BuildServiceProvider().GetRequiredService<BackgroundJobService>().HourlyTask(),
                Cron.Hourly);

            RecurringJob.AddOrUpdate(
                "daily-job",
                () => services.BuildServiceProvider().GetRequiredService<BackgroundJobService>().DailyTask(),
                Cron.Daily);
        });

    }
}