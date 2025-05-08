using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TeslaRent_01.WebApplication.Server.Models
{
    public class ReservationSearchVM : IValidatableObject
    {
        [Required]
        [JsonPropertyName("startLocationId")]
        public int StartLocationId { get; set; }
        [Required]
        [JsonPropertyName("endLocationId")]
        public int EndLocationId { get; set; }
        [Required]
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }
        [Required]
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate.Date < DateTime.UtcNow.Date)
            {
                yield return new ValidationResult("Start date cannot be in the past.", new[] { nameof(StartDate) });
            }

            if (EndDate.Date <= StartDate.Date)
            {
                yield return new ValidationResult("End date must be after the start date.", new[] { nameof(EndDate) });
            }
        }
    }
}
