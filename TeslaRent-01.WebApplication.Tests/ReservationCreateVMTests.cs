using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Tests;

public class ReservationCreateVMTests
{
    [Fact]
    public void Validate_ReturnNoErrors_ModelIsValid()
    {
        ReservationCreateVM reservationCreateVM = new ReservationCreateVM
        {
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(2),
            FirstName = "John",
            LastName = "Doe",
            Email = "John.Doe@gmail.com",
            CarModelId = 1,
            CarModelName = "Tesla Model 3",
            Price = 1000,
            StartLocationId = 1,
            EndLocationId = 2
        };

        var validationResults = reservationCreateVM.Validate(new ValidationContext(reservationCreateVM));
        var validationErrors = validationResults.ToList();

        Assert.Empty(validationErrors);
    }

    [Fact]
    public void Validate_ReturnError_StartDateInPast()
    {
        ReservationCreateVM reservationCreateVM = new ReservationCreateVM
        {
            StartDate = DateTime.UtcNow.AddDays(-1),
            EndDate = DateTime.UtcNow.AddDays(1),
            FirstName = "John",
            LastName = "Doe",
            Email = "John.Doe@gmail.com",
            CarModelId = 1,
            CarModelName = "Tesla Model 3",
            Price = 1000,
            StartLocationId = 1,
            EndLocationId = 2
        };

        var validationResults = reservationCreateVM.Validate(new ValidationContext(reservationCreateVM));
        var validationErrors = validationResults.ToList();

        Assert.Contains(validationResults, vr => vr.ErrorMessage == "Start date cannot be in the past.");
    }

    [Fact]
    public void Validate_ReturnError_EndDateEqualToStartDate()
    {
        ReservationCreateVM reservationCreateVM = new ReservationCreateVM
        {
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(1),
            FirstName = "John",
            LastName = "Doe",
            Email = "John.Doe@gmail.com",
            CarModelId = 1,
            CarModelName = "Tesla Model 3",
            Price = 1000,
            StartLocationId = 1,
            EndLocationId = 2
        };

        var validationResults = reservationCreateVM.Validate(new ValidationContext(reservationCreateVM));
        var validationErrors = validationResults.ToList();

        Assert.Contains(validationResults, vr => vr.ErrorMessage == "End date must be after the start date.");
    }

    [Fact]
    public void Validate_ReturnError_EndDateLowerThanStartDate()
    {
        ReservationCreateVM reservationCreateVM = new ReservationCreateVM
        {
            StartDate = DateTime.UtcNow.AddDays(2),
            EndDate = DateTime.UtcNow.AddDays(1),
            FirstName = "John",
            LastName = "Doe",
            Email = "John.Doe@gmail.com",
            CarModelId = 1,
            CarModelName = "Tesla Model 3",
            Price = 1000,
            StartLocationId = 1,
            EndLocationId = 2
        };

        var validationResults = reservationCreateVM.Validate(new ValidationContext(reservationCreateVM));
        var validationErrors = validationResults.ToList();

        Assert.Contains(validationResults, vr => vr.ErrorMessage == "End date must be after the start date.");
    }

    [Fact]
    public void Validate_ReturnError_FirstNameEmpty()
    {
        ReservationCreateVM reservationCreateVM = new ReservationCreateVM
        {
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(2),
            FirstName = "",
            LastName = "Doe",
            Email = "John.Doe@gmail.com",
            CarModelId = 1,
            CarModelName = "Tesla Model 3",
            Price = 1000,
            StartLocationId = 1,
            EndLocationId = 2
        };

        var validationResults = reservationCreateVM.Validate(new ValidationContext(reservationCreateVM));
        var validationErrors = validationResults.ToList();

        Assert.Contains(validationResults, vr => vr.ErrorMessage == "First name is required.");
    }

    [Fact]
    public void Validate_ReturnError_LastNameEmpty()
    {
        ReservationCreateVM reservationCreateVM = new ReservationCreateVM
        {
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(2),
            FirstName = "John",
            LastName = "",
            Email = "John.Doe@gmail.com",
            CarModelId = 1,
            CarModelName = "Tesla Model 3",
            Price = 1000,
            StartLocationId = 1,
            EndLocationId = 2
        };

        var validationResults = reservationCreateVM.Validate(new ValidationContext(reservationCreateVM));
        var validationErrors = validationResults.ToList();

        Assert.Contains(validationResults, vr => vr.ErrorMessage == "Last name is required.");
    }

    [Fact]
    public void Validate_ReturnError_EmailEmpty()
    {
        ReservationCreateVM reservationCreateVM = new ReservationCreateVM
        {
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(2),
            FirstName = "John",
            LastName = "Doe",
            Email = "",
            CarModelId = 1,
            CarModelName = "Tesla Model 3",
            Price = 1000,
            StartLocationId = 1,
            EndLocationId = 2
        };

        var validationResults = reservationCreateVM.Validate(new ValidationContext(reservationCreateVM));
        var validationErrors = validationResults.ToList();

        Assert.Contains(validationResults, vr => vr.ErrorMessage == "Email is required.");
    }

    [Fact]
    public void Validate_ReturnError_EmailInvalid()
    {
        ReservationCreateVM reservationCreateVM = new ReservationCreateVM
        {
            StartDate = DateTime.UtcNow.AddDays(1),
            EndDate = DateTime.UtcNow.AddDays(2),
            FirstName = "John",
            LastName = "Doe",
            Email = "John",
            CarModelId = 1,
            CarModelName = "Tesla Model 3",
            Price = 1000,
            StartLocationId = 1,
            EndLocationId = 2
        };

        var validationResults = reservationCreateVM.Validate(new ValidationContext(reservationCreateVM));
        var validationErrors = validationResults.ToList();

        Assert.Contains(validationResults, vr => vr.ErrorMessage == "Invalid email format.");
    }
}
