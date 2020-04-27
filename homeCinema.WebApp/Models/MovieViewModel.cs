using homeCinema.WebApp.Infrastructures.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace homeCinema.WebApp.Models
{
    public class MovieViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [BindNever]
        public string Image { get; set; }
        public int GenreId { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte Rating { get; set; }
        public string TrailerURI { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new MovieViewModelValidator();
            var result = validator.Validate(this);

            return result.Errors
                .Select(x => new ValidationResult(x.ErrorMessage, new[] { x.PropertyName }));
        }
    }
}
