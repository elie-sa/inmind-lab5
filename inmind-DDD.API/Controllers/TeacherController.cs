using inmind_DDD.Application.Services.Features.Teachers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("teachers")]
public class TeacherController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST: api/teacher
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherCommand command)
    {
        var teacherId = await _mediator.Send(command);
        return Ok(teacherId);

    }
}