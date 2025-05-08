using System.Text.Json.Serialization;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Configuration
{
    [JsonSourceGenerationOptions(WriteIndented = true)]

    [JsonSerializable(typeof(CarModelVM))]
    [JsonSerializable(typeof(List<CarModelVM>))]

    [JsonSerializable(typeof(LocationVM))]
    [JsonSerializable(typeof(List<LocationVM>))]

    [JsonSerializable(typeof(ReservationCreateVM))]

    [JsonSerializable(typeof(ReservationSearchVM))]

    public partial class AppJsonContext : JsonSerializerContext
    {
    }
}
