using inmind_DDD.Contracts.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace inmind_DDD.Application.Features.Teachers.Commands;

public class UploadProfilePictureCommandHandler : IRequestHandler<UploadProfilePictureCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public UploadProfilePictureCommandHandler(IAppDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task<bool> Handle(UploadProfilePictureCommand request, CancellationToken cancellationToken)
    {
        if (request.File == null || request.File.Length == 0)
            throw new ArgumentException("File is required.");

        var teacher = await _context.Teachers.FindAsync(request.TeacherId, cancellationToken);
        if (teacher == null)
            throw new KeyNotFoundException($"Teacher with ID {request.TeacherId} not found.");

        if (string.IsNullOrEmpty(_environment.WebRootPath))
            throw new DirectoryNotFoundException("Web root path is not configured.");

        // used to generate a unique name by creating a random guid
        var fileName = Guid.NewGuid() + Path.GetExtension(request.File.FileName);
        var filePath = Path.Combine(_environment.WebRootPath, fileName);

        try
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(fileStream, cancellationToken);
            }
        }
        catch (Exception ex)
        {
            throw new IOException("Error saving the file.", ex);
        }

        teacher.ProfilePicture = fileName;
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}