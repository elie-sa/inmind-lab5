using System.Net;
using System.Text.Json;
using inmind_DDD.API.Resources;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Localization;

namespace inmind_DDD.API.ExceptionHandlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IStringLocalizer<Messages> _localizer;

    public GlobalExceptionHandler(IStringLocalizer<Messages> localizer)
    {
        _localizer = localizer;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        string localizedMessage;

        switch (exception)
        {
            case ArgumentException:
                localizedMessage = _localizer["BadRequestError"];
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;

            case KeyNotFoundException:
                localizedMessage = _localizer["NotFoundError"];
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                break;

            default:
                localizedMessage = _localizer["InternalServerError"];
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        var response = new { message = localizedMessage };
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response), cancellationToken);
        return true;
    }
}