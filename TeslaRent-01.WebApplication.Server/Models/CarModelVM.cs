using System.Text.Json.Serialization;

namespace TeslaRent_01.WebApplication.Server.Models
{
    public sealed record CarModelVM
    {
        // IDs
        [JsonPropertyName("id")]
        public int CarModelId { get; set; }
        // STRINGS
        [JsonPropertyName("name")]
        public string CarModelName { get; set; }
        [JsonPropertyName("bodyType")]
        public string CarBodyType { get; init; }
        [JsonPropertyName("description")]
        public string CarDescription { get; init; }
        // NUMBERS
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("seats")]
        public int Seats { get; set; }
        [JsonPropertyName("maxSpeed")]
        public int MaxSpeed { get; set; }
        [JsonPropertyName("maxRange")]
        public int MaxRange { get; set; }
        [JsonPropertyName("acceleration")]
        public decimal Acceleration { get; set; }
    }
}
