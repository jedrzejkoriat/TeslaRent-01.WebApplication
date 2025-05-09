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

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

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

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ISqlService, SqlService>();

builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddTransient<IEmailSender, EmailSenderService>(provider => new EmailSenderService(sendGridApiKey, sendGridEmail));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();

builder.Services.AddScoped<ITeslaRentService, TeslaRentService>();

builder.Services.AddScoped<IEmailBuilder, EmailBuilder>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// GET /api/location
app.MapGet("/api/location", async (HttpContext context, ITeslaRentService teslaReservationService, ILogger<Program> logger) =>
{
    logger.LogInformation("Received request: {Method} {Path}", context.Request.Method, context.Request.Path);
    try
    {
        // Call method
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
    async (HttpContext context, ITeslaRentService teslaReservationService, string startLocationId, string startDate, string endLocationId, string endDate, ILogger<Program> logger) =>
    {
        logger.LogInformation("Received request: {Method} {Path}", context.Request.Method, context.Request.Path);
        try
        {
            // Create view model
            ReservationSearchVM reservationSearchVM = new ReservationSearchVM
            {
                StartLocationId = Int32.Parse(startLocationId),
                EndLocationId = Int32.Parse(endLocationId),
                StartDate = DateTime.Parse(startDate),
                EndDate = DateTime.Parse(endDate)
            };

            // Check if the viewmodel is valid
            var validationResults = reservationSearchVM.Validate(new ValidationContext(reservationSearchVM));
            var validationErrors = validationResults.ToList();

            if (validationErrors.Any())
            {
                var errorMessages = validationErrors.Select(v => v.ErrorMessage);
                return Results.BadRequest(new { Errors = errorMessages });
            }

            // Call method
            List<CarModelVM> cars = await teslaReservationService.GetAvailableCarVMsAsync(reservationSearchVM);
            logger.LogInformation("Sent response: {StatusCode} {Path}", context.Response.StatusCode, context.Request.Path);
            return Results.Ok(cars);
        }
        catch (FormatException ex)
        {
            logger.LogError(ex, "Error processing request: {Method} {Path}", context.Request.Method, context.Request.Path);
            return Results.BadRequest(new { Error = "Invalid format of input parameters.", Details = ex.Message });

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
        // Check if the viewmodel is valid
        var validationResults = reservationCreateVM.Validate(new ValidationContext(reservationCreateVM));
        var validationErrors = validationResults.ToList();

        if (validationErrors.Any())
        {
            var errorMessages = validationErrors.Select(v => v.ErrorMessage);
            return Results.BadRequest(new { Errors = errorMessages });
        }

        // Call method
        await teslaReservationService.CreateReservationAsync(reservationCreateVM);
        logger.LogInformation("Sent response: {StatusCode} {Path}", context.Response.StatusCode, context.Request.Path);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error processing request: {Method} {Path}", context.Request.Method, context.Request.Path);
        return Results.Problem(ex.Message);
    }
});

app.MapFallbackToFile("/index.html");

app.Run();
