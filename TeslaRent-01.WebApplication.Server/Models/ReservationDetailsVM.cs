using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TeslaRent_01.WebApplication.Server.Models
{
    public sealed record ReservationDetailsVM
    {
        [JsonPropertyName("startLocation")]
        public LocationDetailsVM StartLocationVM { get; set; }
        [JsonPropertyName("endLocation")]
        public LocationDetailsVM EndLocationVM { get; set; }
        [JsonPropertyName("reservation")]
        public ReservationCreateVM ReservationCreateVM { get; set; }
    }
}
