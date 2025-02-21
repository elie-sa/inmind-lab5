using inmind_DDD.Contracts.Interfaces;
using inmind_DDD.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.API.Controllers;

[ApiController]
public class ControllerDemo: ControllerBase
{
    private readonly IAppDbContext _context;

    public ControllerDemo(IAppDbContext context)
    {
        _context = context;
    }
    
    [Route("/")]
    [HttpGet]
    public List<Student> Get()
    {
        return _context.Students.ToList()
            ;
    }
    
}