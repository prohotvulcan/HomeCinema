using homeCinema.WebApp.Infrastructures.Validators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace homeCinema.WebApp.Models
{
    public class RegistrationViewModel : IValidatableObject
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new RegistrationViewModelValidator();
            var result = validator.Validate(this);

            return result.Errors
                .Select(x => new ValidationResult(x.ErrorMessage, new[] { x.PropertyName }));
        }
    }
}
