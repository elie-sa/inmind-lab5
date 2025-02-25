using inmind_DDD.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace inmind_DDD.API.Controllers;

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/courses")]
[ApiController]
public class CoursesV2Controller : ControllerBase
{
    private readonly IStringLocalizer<Messages> _localizer;

    public CoursesV2Controller(IStringLocalizer<Messages> localizer)
    {
        _localizer = localizer;
    }
    // didnt put all endpoints here only made this for demonstration purposes
    // shouldn't specify the route [Route("all")] but it crashed on swagger (working on postman) so i kept it without same route name as Controller 1 to test
    [HttpGet]
    [Route("all")]
    public IActionResult GetCourses()
    {
        return Ok(new { message = "API Version 2.0" });
    }
}