using inmind_DDD.Application.Features.Students.Commands;
using inmind_DDD.Application.Features.Students.Queries;
using inmind_DDD.Domain.Models;
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
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudentById(int id)
    {
        var student = await _mediator.Send(new GetStudentByIdQuery(id));
        return Ok(student);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<int>> CreateStudent([FromBody] CreateStudentCommand command)
    {
        var studentId = await _mediator.Send(command);
        return Ok(studentId);
    }

    [HttpPut]
    [Route("enrollInCourse")]
    public async Task<ActionResult<int>> EnrollStudent([FromBody] EnrollStudentCommand command)
    {
        await _mediator.Send(command);
        return Ok("Student successfully enrolled.");
    }
}