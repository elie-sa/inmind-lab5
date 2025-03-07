using inmind_DDD.Application.Features.Teachers.Commands;
using inmind_DDD.Application.Features.Teachers.Queries;
using inmind_DDD.Application.Services.Features.Teachers.Commands;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace inmind_DDD.API.Controllers;

[ApiController]
[Route("teachers")]
public class TeacherController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<IQueryable<Teacher>>> Get()
    {
        var result = await _mediator.Send(new GetTeachersQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Teacher>> GetTeacherById(int id)
    {
        var teacher = await _mediator.Send(new GetTeacherByIdQuery(id));
        return Ok(teacher);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherCommand command)
    {
        var teacherId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetTeacherById), new { id = teacherId }, teacherId);
    }
    
    // to make the database simpler i had no connection between teacher and each student grade
    // therefore any teacher can change each student's grade 
    // in an ideal database we would've had authentication to make sure the person adding the grade is a teacher and we woul've let each teacher post only one grade for each course for each student and then update that grade
    [HttpPut]
    [Route("gradeStudent")]
    public async Task<IActionResult> GradeStudent([FromBody] GradeStudentCommand command)
    {
        var output = await _mediator.Send(command);
        return Ok(new { newGrade = output});
    }
    
    [HttpPost]
    [Route("{teacherId}/uploadProfilePicture")]
    public async Task<IActionResult> UploadProfilePicture(int teacherId, IFormFile file)
    {
        
        var command = new UploadProfilePictureCommand
        {
            TeacherId = teacherId,
            File = file
        };

        await _mediator.Send(command);
        return NoContent();
    }
}