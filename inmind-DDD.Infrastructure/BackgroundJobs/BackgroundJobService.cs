using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using inmind_DDD.Infrastructure.Emailing;
using Microsoft.AspNetCore.Http.HttpResults;

namespace inmind_DDD.Infrastructure.BackgroundJobs;

public class BackgroundJobService
{
    private readonly IAppDbContext _context;
    private readonly EmailService _emailSender;

    public BackgroundJobService(IAppDbContext context, EmailService emailSender)
    {
        _context = context;
        _emailSender = emailSender;
    }
    
    // i will raise the students' grades by 1 each hour
    // for simplicity my database didnt include a course-grade relationship so i can't recalculate each student's grade
    public async Task HourlyTask()
    {
        foreach (Student student in _context.Students)
        {
            student.GradeAverage += 1;
        }

        await _context.SaveChangesAsync();
    }

    public async Task DailyTask()
    {
        var subject = "Enrollment Deadline Reminder";
        var body = "This is a reminder about the upcoming enrollment deadline.";
        
        // i dont have the students' email in my database else i would've called context and passed it from here
        // will use my email for testing
        await _emailSender.SendEmailAsync("e.sawmaawad@gmail.com", subject, body);
    }
}