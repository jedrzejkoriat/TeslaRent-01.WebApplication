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

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped<ISqlService, SqlService>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

builder.Services.AddScoped<ITeslaRentService, TeslaRentService>();

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
app.MapGet("/api/location", async(ITeslaRentService teslaReservationService) =>
{
    try
    {
        List<LocationVM> locations = await teslaReservationService.GetAvailableLocationVMsAsync();
        return Results.Ok(locations);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// GET /api/cars/start_location/{startLocationId}/start_date/{startDate}/end_location/{endLocationId}/end_date/{endDate}
app.MapGet("/api/cars/start_location/{startLocationId}/start_date/{startDate}/end_location/{endLocationId}/end_date/{endDate}", 
    async(ITeslaRentService teslaReservationService, 
    string startLocationId,
    string startDate,
    string endLocationId,
    string endDate) =>
{
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

        List<CarModelVM> cars = await teslaReservationService.GetAvailableCarVMsAsync(reservationSearchVM);
        return Results.Ok(cars);
    }
    catch (FormatException ex)
    {
        return Results.BadRequest(new { Error = "Invalid format of input parameters.", Details = ex.Message });

    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }

});

// POST /api/reservation
app.MapPost("/api/reservation", async ([FromBody] ReservationCreateVM reservationCreateVM, ITeslaRentService teslaReservationService) =>
{
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

        await teslaReservationService.CreateReservationAsync(reservationCreateVM);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapFallbackToFile("/index.html");

app.Run();
