using AutoMapper;
using homeCinema.Data.Entities;
using homeCinema.WebApp.Models;
using System.Linq;

namespace homeCinema.WebApp.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Movie, MovieViewModel>()
                .ForMember(vm => vm.Genre, map => map.MapFrom(m => m.Genre.Name))
                .ForMember(vm => vm.GenreId, map => map.MapFrom(m => m.Genre.Id))
                .ForMember(vm => vm.IsAvailable, map => map.MapFrom(m => m.Stocks.Any(s => s.IsAvailable)))
                .ForMember(vm => vm.NumberOfStocks, map => map.MapFrom(m => m.Stocks.Count))
                .ForMember(vm => vm.Image, map => map.MapFrom(m => string.IsNullOrEmpty(m.Image) ? "unknown.jpg" : m.Image));

            CreateMap<Genre, GenreViewModel>()
                .ForMember(vm => vm.NumberOfMovies, map => map.MapFrom(m => m.Movies.Count));

            CreateMap<Stock, StockViewModel>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Rental, RentalViewModel>();
        }
    }
}
