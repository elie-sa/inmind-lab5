using System.Reflection;
using Hangfire;
using inmind_DDD.API;
using inmind_DDD.API.ExceptionHandlers;
using inmind_DDD.Application;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddOData(opt => opt.Select().Filter().OrderBy().Expand().Count());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IExceptionHandler, GlobalExceptionHandler>();

builder.Services.AddLocalization(options => options.ResourcesPath = "");

// adding localization
var supportedCultures = new[] { "en", "fr" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
localizationOptions.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());

// calling the application services found on the application layer to connect to the dbcontext
// also calling MediatR there
builder.Services.AddApplicationServices(builder.Configuration);

// added my own Exception Handler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseRequestLocalization(localizationOptions);

// adding hangfire dashboard (to be able to test using /hangfire and trigger the events)
app.UseHangfireDashboard("/hangfire");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// activating the custom exception handler
app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseApplicationMiddlewares();

app.UseAuthorization();

app.MapControllers();

app.Run();