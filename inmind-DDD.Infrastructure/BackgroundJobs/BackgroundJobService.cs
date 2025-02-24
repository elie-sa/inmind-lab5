using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;

namespace inmind_DDD.Infrastructure.BackgroundJobs;

public class BackgroundJobService
{
    private readonly IAppDbContext _context;

    public BackgroundJobService(IAppDbContext context)
    {
        _context = context;
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
        
    }
}