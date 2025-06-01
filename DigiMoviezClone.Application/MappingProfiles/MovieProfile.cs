using AutoMapper;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Application.DTOs;

namespace DigiMoviezClone.Application.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<CreateMovieDto, Movie>();
        }
    }
}