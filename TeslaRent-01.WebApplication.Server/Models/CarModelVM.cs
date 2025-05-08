using System.Text.Json.Serialization;

namespace TeslaRent_01.WebApplication.Server.Models
{
    public class CarModelVM
    {
        [JsonPropertyName("id")]
        public int CarModelId { get; set; }
        [JsonPropertyName("name")]
        public string CarModelName { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
