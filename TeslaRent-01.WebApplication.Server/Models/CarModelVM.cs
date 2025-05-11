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
        public string Name { get; set; }
        [JsonPropertyName("bodyType")]
        public string BodyType { get; init; }
        [JsonPropertyName("description")]
        public string Description { get; init; }
        // NUMBERS
        [JsonPropertyName("dailyPrice")]
        public decimal DailyPrice { get; set; }
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
