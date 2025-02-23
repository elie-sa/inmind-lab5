using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace inmind_DDD.Application.Features.Teachers.Commands;

public class UploadProfilePictureCommand : IRequest<bool>
{
    public IFormFile File { get; set; }
    public int TeacherId { get; set; }
}