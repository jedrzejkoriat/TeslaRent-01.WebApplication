using System.Text.Json.Serialization;

namespace TeslaRent_01.WebApplication.Server.Models
{
    public class ReservationSearchVM
    {
        [JsonPropertyName("startLocationId")]
        public int StartLocationId { get; set; }
        [JsonPropertyName("endLocationId")]
        public int EndLocationId { get; set; }
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }
    }
}
