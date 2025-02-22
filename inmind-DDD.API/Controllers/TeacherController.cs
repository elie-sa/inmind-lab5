using inmind_DDD.Application.Features.Teachers.Commands;
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

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherCommand command)
    {
        var teacherId = await _mediator.Send(command);
        return Ok(teacherId);
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
}