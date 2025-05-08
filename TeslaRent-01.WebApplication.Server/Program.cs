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

builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

builder.Services.AddScoped<ITeslaReservationService, TeslaReservationService>();

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

app.MapGet("/api/location", async(ITeslaReservationService teslaReservationService) =>
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

app.MapGet("/api/cars/start_location/{startLocationId}/start_date/{startDate}/end_location/{endLocationId}/end_date/{endDate}", 
    async(ITeslaReservationService teslaReservationService, 
    string startLocationId,
    string startDate,
    string endLocationId,
    string endDate) =>
{
    ReservationSearchVM reservationSearchVM = new ReservationSearchVM
    {
        StartLocationId = Int32.Parse(startLocationId),
        EndLocationId = Int32.Parse(endLocationId),
        StartDate = DateTime.Parse(startDate),
        EndDate = DateTime.Parse(endDate)
    };

    var validationResults = reservationSearchVM.Validate(new ValidationContext(reservationSearchVM));
    var validationErrors = validationResults.ToList();

    if (validationErrors.Any())
    {
        var errorMessages = validationErrors.Select(v => v.ErrorMessage);
        return Results.BadRequest(new { Errors = errorMessages });
    }

    try
    {
        List<CarModelVM> cars = await teslaReservationService.GetAvailableCarVMsAsync(reservationSearchVM);
        return Results.Ok(cars);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }

});

app.MapPost("/api/reservation", async ([FromBody] ReservationCreateVM reservationCreateVM, ITeslaReservationService teslaReservationService) =>
{
    var validationResults = reservationCreateVM.Validate(new ValidationContext(reservationCreateVM));
    var validationErrors = validationResults.ToList();

    if (validationErrors.Any())
    {
        var errorMessages = validationErrors.Select(v => v.ErrorMessage);
        return Results.BadRequest(new { Errors = errorMessages });
    }

    try
    {
        await teslaReservationService.CreateReservationAsync(reservationCreateVM);
        return Results.Ok();
    }
    catch (InvalidOperationException ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapFallbackToFile("/index.html");

app.Run();
