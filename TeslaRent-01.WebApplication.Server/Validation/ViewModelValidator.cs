using System.ComponentModel.DataAnnotations;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Validation
{
    public static class ViewModelValidator
    {
        public static void Validate<T>(T viewModel) where T : class, IValidatableObject
        {
            var validationResults = viewModel.Validate(new ValidationContext(viewModel));
            var validationErrors = validationResults.ToList();

            if (validationErrors.Any())
            {
                var errorMessages = validationErrors.Select(v => v.ErrorMessage);
                throw new ValidationException(string.Join("\n", errorMessages));
            }
        }
    }
}
