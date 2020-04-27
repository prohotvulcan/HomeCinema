using FluentValidation;
using homeCinema.WebApp.Models;
using System;

namespace homeCinema.WebApp.Infrastructures.Validators
{
    public class StockViewModelValidator : AbstractValidator<StockViewModel>
    {
        public StockViewModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Invalid stock item");

            RuleFor(x => x.UniqueKey)
                .NotEqual(Guid.Empty)
                .WithMessage("Invalid stock item");
        }
    }
}
