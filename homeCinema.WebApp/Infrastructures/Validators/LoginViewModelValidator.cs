using FluentValidation;
using homeCinema.WebApp.Models;

namespace homeCinema.WebApp.Infrastructures.Validators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Invalid username");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Invalid password");
        }
    }
}
