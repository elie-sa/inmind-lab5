using inmind_DDD.Application.Features.Courses.Commands;
using inmind_DDD.Application.Features.Courses.Queries;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace inmind_DDD.API.Controllers;



[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/courses")]
public class CourseController1 : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController1(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [EnableQuery] 
    public async Task<IActionResult> GetCourses()
    {
        var result = await _mediator.Send(new GetCoursesQuery());
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourseById(int id)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery(id));
        return Ok(course);
    }
    
    [HttpGet("localCaching/{id}")]
    public async Task<ActionResult<Course>> GetCourseByIdLocalCaching(int id)
    {
        var course = await _mediator.Send(new GetCourseByIdLocalCachingQuery(id));
        return Ok(course);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<int>> CreateCourse([FromBody] CreateCourseCommand command)
    {
        var courseId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCourseById), new { id = courseId }, courseId);
    }

    [HttpPut]
    [Route("updateMaxCapacity")]
    public async Task<ActionResult<bool>> UpdateMaxCapacity([FromBody] UpdateMaxStudentsCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    [Route("updateTimeSlot")]
    public async Task<ActionResult<bool>> UpdateTimeSlot([FromBody] AssignToSlotCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    } 
}