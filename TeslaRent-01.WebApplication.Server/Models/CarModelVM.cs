using System.Text.Json.Serialization;

namespace TeslaRent_01.WebApplication.Server.Models
{
    public class CarModelVM
    {
        // IDs
        [JsonPropertyName("id")]
        public int CarModelId { get; set; }
        // STRINGS
        [JsonPropertyName("name")]
        public string CarModelName { get; set; }
        // NUMBERS
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
