using System.Text.Json.Serialization;

namespace TeslaRent_01.WebApplication.Server.Models
{
    public class CarModelVM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
