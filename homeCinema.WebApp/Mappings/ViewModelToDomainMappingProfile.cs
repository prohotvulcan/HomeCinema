using AutoMapper;
using homeCinema.Data.Entities;
using homeCinema.WebApp.Models;

namespace homeCinema.WebApp.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<MovieViewModel, Movie>()
                .ForMember(m => m.Genre, map => map.Ignore());
        }
    }
}
