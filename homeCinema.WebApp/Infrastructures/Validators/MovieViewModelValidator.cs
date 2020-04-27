using FluentValidation;
using homeCinema.WebApp.Models;

namespace homeCinema.WebApp.Infrastructures.Validators
{
    public class MovieViewModelValidator : AbstractValidator<MovieViewModel>
    {
        public MovieViewModelValidator()
        {
            RuleFor(x => x.GenreId)
                .GreaterThan(0)
                .WithMessage("Select a Genre");

            RuleFor(x => x.Director)
                .NotEmpty()
                .Length(1, 100)
                .WithMessage("Select a Director");

            RuleFor(x => x.Writer)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Select a Writer");

            RuleFor(x => x.Producer)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Select a Producer");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Select a Description");

            RuleFor(x => x.Rating)
                .InclusiveBetween((byte)0, (byte)5)
                .WithMessage("Rating must be less than or equal to 5");

            RuleFor(x => x.TrailerURI)
                .NotEmpty()
                .Must(ValidTrailerURI)
                .WithMessage("Only Youtube Trailers are supported");
        }

        private bool ValidTrailerURI(string uri)
        {
            return (!string.IsNullOrEmpty(uri) 
                && uri.ToLower().StartsWith("https://www.youtube.com/watch?"));
        }
    }
}
