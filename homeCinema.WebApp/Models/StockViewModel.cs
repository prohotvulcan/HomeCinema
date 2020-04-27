using homeCinema.WebApp.Infrastructures.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace homeCinema.WebApp.Models
{
    public class StockViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public Guid UniqueKey { get; set; }
        public bool IsAvailable { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new StockViewModelValidator();
            var result = validator.Validate(this);

            return result.Errors
                .Select(x => new ValidationResult(x.ErrorMessage, new[] { x.PropertyName }));
        }
    }
}
