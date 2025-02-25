using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace inmind_DDD.Infrastructure.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        var request = context.Request;

        _logger.LogInformation("Incoming request: {Method} {Path} from {IpAddress}",
            request.Method, request.Path, context.Connection.RemoteIpAddress);

        await _next(context);

        stopwatch.Stop();
        var response = context.Response;

        _logger.LogInformation("Outgoing response: {StatusCode} for {Method} {Path} in {ElapsedMilliseconds}ms",
            response.StatusCode, request.Method, request.Path, stopwatch.ElapsedMilliseconds);
    }
}