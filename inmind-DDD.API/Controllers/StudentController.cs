using inmind_DDD.Application.Features.Students.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace inmind_DDD.API.Controllers;

[ApiController]
[Route("students")]
public class StudentController: ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<int>> CreateStudent([FromBody] CreateStudentCommand command)
    {
        var studentId = await _mediator.Send(command);
        return Ok(studentId);
    }    
}