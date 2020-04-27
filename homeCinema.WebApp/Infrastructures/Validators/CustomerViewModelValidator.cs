using FluentValidation;
using homeCinema.WebApp.Models;
using System;

namespace homeCinema.WebApp.Infrastructures.Validators
{
    public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(1, 100)
                .WithMessage("First Name must be between 1 - 100 characters");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Length(1, 100)
                .WithMessage("Last Name must be between 1 - 100 characters");

            RuleFor(x => x.IdentityCard)
                .NotEmpty()
                .Length(1, 100)
                .WithMessage("Identity Card Name must be between 1 - 100 characters");

            RuleFor(x => x.DateOfBirth)
                .NotNull()
                .LessThan(DateTime.Now.AddYears(-16))
                .WithMessage("Customer must be at least 16 years old.");

            RuleFor(x => x.Mobile)
                .NotEmpty()
                .Matches(@"^\d{10}$")
                .Length(10)
                .WithMessage("Mobile phone must have 10 digits");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Enter a valid Email address");
        }
    }
}
