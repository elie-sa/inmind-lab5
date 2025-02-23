using inmind_DDD.Application.Features.Students.Commands;
using inmind_DDD.Application.Features.Students.Queries;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

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
    
    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IQueryable<Student>>> Get()
    {
        var result = await _mediator.Send(new GetStudentsQuery());
        return Ok(result);
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
        return CreatedAtAction(nameof(GetStudentById), new { id = studentId }, studentId);
    }

    [HttpPut]
    [Route("enrollInCourse")]
    public async Task<ActionResult<int>> EnrollStudent([FromBody] EnrollStudentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}