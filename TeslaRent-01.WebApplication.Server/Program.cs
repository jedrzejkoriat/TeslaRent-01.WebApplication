using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;
using TeslaRent_01.WebApplication.Server.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TeslaRent_01.WebApplication.Server.Services;
using TeslaRent_01.WebApplication.Server.Configuration;
using TeslaRent_01.WebApplication.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.UI.Services;
using TeslaRent_01.WebApplication.Server.Builders;
using PdfSharp.Pdf;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Get essential connection strings
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("connectionString is not set.");
}

var sendGridApiKey = builder.Configuration.GetSection("SendGrid")["ApiKey"];
if (string.IsNullOrEmpty(sendGridApiKey))
{
    throw new Exception("SendGrid API key is not set.");
}

var sendGridEmail = builder.Configuration.GetSection("SendGrid")["Email"];
if (string.IsNullOrEmpty(sendGridEmail))
{
    throw new Exception("SendGrid email is not set.");
}

// Add logger
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

// Add db context
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Add automapper
builder.Services.AddAutoMapper(typeof(MapperConfig));

// Add services
builder.Services.AddTransient<IEmailSender, EmailSenderService>(provider => new EmailSenderService(sendGridApiKey, sendGridEmail));
builder.Services.AddScoped<ISqlService, SqlService>();

// Add builders
builder.Services.AddScoped<IPdfBuilder, PdfBuilder>();
builder.Services.AddScoped<IEmailBuilder, EmailBuilder>();

// Add main app service
builder.Services.AddScoped<ITeslaRentService, TeslaRentService>();

// Add repositories
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

// GET /api/location
app.MapGet("/api/location", async (HttpContext context, ITeslaRentService teslaReservationService, ILogger<Program> logger) =>
{
    logger.LogInformation("Received request: {Method} {Path}", context.Request.Method, context.Request.Path);
    try
    {
        List<LocationNameVM> locations = await teslaReservationService.GetAvailableLocationVMsAsync();
        logger.LogInformation("Sent response: {StatusCode} {Path}", context.Response.StatusCode, context.Request.Path);
        return Results.Ok(locations);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error processing request: {Method} {Path}", context.Request.Method, context.Request.Path);
        return Results.BadRequest(ex.Message);
    }
});

// GET /api/cars/start_location/{startLocationId}/start_date/{startDate}/end_location/{endLocationId}/end_date/{endDate}
app.MapGet("/api/cars/start_location/{startLocationId}/start_date/{startDate}/end_location/{endLocationId}/end_date/{endDate}",
    async (HttpContext context, ITeslaRentService teslaReservationService, int startLocationId, DateTime startDate, int endLocationId, DateTime endDate, ILogger<Program> logger) =>
    {
        logger.LogInformation("Received request: {Method} {Path}", context.Request.Method, context.Request.Path);
        try
        {
            List<CarModelVM> cars = await teslaReservationService.GetAvailableCarVMsAsync(startLocationId, endLocationId, startDate, endDate);
            logger.LogInformation("Sent response: {StatusCode} {Path}", context.Response.StatusCode, context.Request.Path);
            return Results.Ok(cars);
        }
        catch (ValidationException ex)
        {
            logger.LogError(ex, "Error processing request: {Method} {Path}", context.Request.Method, context.Request.Path);
            return Results.BadRequest(new { Error = "Validation error.", Details = ex.Message });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error processing request: {Method} {Path}", context.Request.Method, context.Request.Path);
            return Results.Problem(ex.Message);
        }

    });

// POST /api/reservation
app.MapPost("/api/reservation", async (HttpContext context, [FromBody] ReservationCreateVM reservationCreateVM, ITeslaRentService teslaReservationService, ILogger<Program> logger) =>
{
    logger.LogInformation("Received request: {Method} {Path}", context.Request.Method, context.Request.Path);
    try
    {
        MemoryStream reservationDocument = await teslaReservationService.CreateReservationAsync(reservationCreateVM);
        logger.LogInformation("Sent response: {StatusCode} {Path}", context.Response.StatusCode, context.Request.Path);
        return Results.File(reservationDocument, "application/pdf", "Reservation_Confirmation.pdf");
    }
    catch (ValidationException ex)
    {
        logger.LogError(ex, "Error processing request: {Method} {Path}", context.Request.Method, context.Request.Path);
        return Results.BadRequest(new { Error = "Validation error.", Details = ex.Message });
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error processing request: {Method} {Path}", context.Request.Method, context.Request.Path);
        return Results.Problem(ex.Message);
    }
});

app.Run();
