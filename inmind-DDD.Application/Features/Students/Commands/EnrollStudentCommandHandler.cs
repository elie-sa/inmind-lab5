using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Application.Features.Students.Commands;

public class EnrollStudentCommandHandler: IRequestHandler<EnrollStudentCommand, bool>
{
    private readonly IAppDbContext _context;

    public EnrollStudentCommandHandler(IAppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(EnrollStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _context.Students.FindAsync(request.StudentId, cancellationToken);
        if (student == null)
        {
            throw new ArgumentException($"Student with id {request.StudentId} does not exist.");
        }
        
        var course = await _context.Courses
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.Id == request.CourseId, cancellationToken);
        if (course == null)
        {
            throw new ArgumentException($"Course with id {request.CourseId} does not exist.");
        }

        if (DateTime.Now < course.EnrollmentStart)
        {
            throw new ArgumentException("You cannot enroll in this course. Enrollment hasn't started yet.");
        }

        if (DateTime.Now > course.EnrollmentEnd)
        {
            throw new ArgumentException("You cannot enroll in this course. Enrollment has ended.");
        }
        
        if (course.Students == null)
        {
            course.Students = new List<Student>();
        }

        if (course.Students.Contains(student))
        {
            throw new ArgumentException("You are already enrolled in this course.");
        }


        if (course.Students.Count == course.MaxStudents)
        {
            throw new Exception("Class capacity is full.");
        }
        
        course.Students.Add(student);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}