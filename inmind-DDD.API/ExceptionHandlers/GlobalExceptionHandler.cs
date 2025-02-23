using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace inmind_DDD.API.ExceptionHandlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";
        var response = new { message = exception.Message };
        int statusCode;

        switch (exception)
        {
            case KeyNotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                break;
            case ArgumentException:
                statusCode = (int)HttpStatusCode.BadRequest;
                break;
            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response), cancellationToken);
        return true; 
    }
}