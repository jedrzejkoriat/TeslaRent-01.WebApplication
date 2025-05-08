using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TeslaRent_01.WebApplication.Server.Models
{
    public class ReservationSearchVM : IValidatableObject
    {
        // IDs
        [JsonPropertyName("startLocationId")]
        public int StartLocationId { get; set; }
        [JsonPropertyName("endLocationId")]
        public int EndLocationId { get; set; }
        // DATES
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Check if StartDate is int the past
            if (StartDate.Date < DateTime.UtcNow.Date)
            {
                yield return new ValidationResult("Start date cannot be in the past.", new[] { nameof(StartDate) });
            }

            // Check if EndDate is after StartDate
            if (EndDate.Date <= StartDate.Date)
            {
                yield return new ValidationResult("End date must be after the start date.", new[] { nameof(EndDate) });
            }
        }
    }
}
