using System.Text.Json.Serialization;

namespace TeslaRent_01.WebApplication.Server.Models
{
    public class ReservationCreateVM : ReservationSearchVM
    {
        [JsonPropertyName("carModelId")]
        public int CarModelId { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
