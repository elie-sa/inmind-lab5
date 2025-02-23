using System.Reflection;
using inmind_DDD.API.ExceptionHandlers;
using inmind_DDD.Application;
using inmind_DDD.Application.Services;
using MediatR;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddOData(opt => opt.Select().Filter().OrderBy().Expand().Count());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// calling the application services found on the application layer to connect to the dbcontext
// also calling MediatR there
builder.Services.AddApplicationServices(builder.Configuration);

// added my own Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// activating the custom exception handler
app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();