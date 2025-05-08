using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;
using TeslaRent_01.WebApplication.Server.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TeslaRent_01.WebApplication.Server.Services;
using TeslaRent_01.WebApplication.Server.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(MapperConfig));

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

app.MapFallbackToFile("/index.html");

app.Run();
