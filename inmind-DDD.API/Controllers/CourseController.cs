using inmind_DDD.Application.Features.Courses.Commands;
using inmind_DDD.Application.Features.Courses.Queries;
using inmind_DDD.Domain.Models;
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
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourseById(int id)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery(id));
        return Ok(course);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<int>> CreateCourse([FromBody] CreateCourseCommand command)
    {
        var courseId = await _mediator.Send(command);
        return Ok(courseId);
    }

    [HttpPut]
    [Route("updateMaxCapacity")]
    public async Task<ActionResult<bool>> UpdateMaxCapacity([FromBody] UpdateMaxStudentsCommand command)
    {
        await _mediator.Send(command);
        return Ok("Max capacity updated.");
    }

    [HttpPut]
    [Route("updateTimeSlot")]
    public async Task<ActionResult<bool>> UpdateTimeSlot([FromBody] AssignToSlotCommand command)
    {
        await _mediator.Send(command);
        return Ok("Time slot updated.");
    } 
}