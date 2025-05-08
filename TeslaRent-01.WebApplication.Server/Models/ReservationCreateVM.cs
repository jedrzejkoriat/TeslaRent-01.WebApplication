using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TeslaRent_01.WebApplication.Server.Models
{
    public class ReservationCreateVM : ReservationSearchVM
    {
        // IDs
        [JsonPropertyName("carModelId")]
        public int CarModelId { get; set; }
        // STRINGS
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        // NUMBERS
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Check if the base class validation is successful
            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }

            // Check if strings are properly entered
            if (string.IsNullOrEmpty(FirstName))
            {
                yield return new ValidationResult("First name is required.", new[] { nameof(FirstName) });
            }

            if (string.IsNullOrEmpty(LastName))
            {
                yield return new ValidationResult("Last name is required.", new[] { nameof(LastName) });
            }

            if (string.IsNullOrEmpty(Email))
            {
                yield return new ValidationResult("Email is required.", new[] { nameof(Email) });
            }
            else if (!new EmailAddressAttribute().IsValid(Email))
            {
                yield return new ValidationResult("Invalid email format.", new[] { nameof(Email) });
            }

        }
    }
}
