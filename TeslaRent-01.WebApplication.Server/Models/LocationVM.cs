using System.Text.Json.Serialization;

namespace TeslaRent_01.WebApplication.Server.Models
{
    public class LocationVM
    {
        // IDs
        [JsonPropertyName("id")]
        public int Id { get; set; }
        // STRINGS
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
