using inmind_DDD.Application.Features.Courses.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace inmind_DDD.API.Controllers;

[ApiController]
[Route("courses")]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> CreateCourse([FromBody] CreateCourseCommand command)
    {
        var courseId = await _mediator.Send(command);
        return Ok(courseId);
    }
    
}