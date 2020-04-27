using FluentValidation;
using homeCinema.WebApp.Models;

namespace homeCinema.WebApp.Infrastructures.Validators
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Invalid username");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Invalid password");

            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid email address");
        }
    }
}
