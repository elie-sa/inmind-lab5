using inmind_DDD.Application.Features.TimeSlots.Commands;
using inmind_DDD.Application.Features.TimeSlots.Queries;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("timeslots")]
public class TimeSlotController : ControllerBase
{
    private readonly IMediator _mediator;

    public TimeSlotController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /*
    {
        "startTime": "08:30:20",
        "endTime": "09:30:20",
        "teacherId": 1
    } 
    
    example of json request (swagger doesn't document startTime and endTime correctly)
     */
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TimeSlot>> GetTimeSlotById(int id)
    {
        var timeSlot = await _mediator.Send(new GetTimeSlotByIdQuery(id));
        return Ok(timeSlot);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTimeSlot([FromBody] CreateTimeSlotCommand command)
    {
        var timeSlotId = await _mediator.Send(command);
        return Ok(timeSlotId);
    }
}