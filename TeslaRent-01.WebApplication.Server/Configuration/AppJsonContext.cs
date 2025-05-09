using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Configuration
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ProblemDetails))]

    [JsonSerializable(typeof(CarModelVM))]
    [JsonSerializable(typeof(List<CarModelVM>))]

    [JsonSerializable(typeof(LocationNameVM))]
    [JsonSerializable(typeof(List<LocationNameVM>))]

    [JsonSerializable(typeof(ReservationCreateVM))]

    [JsonSerializable(typeof(ReservationSearchVM))]

    public partial class AppJsonContext : JsonSerializerContext
    {
    }
}
