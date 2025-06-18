using AutoMapper;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.API.DTOs.Movie;
using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Application.DTOs;

namespace DigiMoviezClone.Application.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieResponseDto>();
            CreateMap<MovieRequestDto, Movie>();
            CreateMap<Movie, MovieDto>();
        }

     
        
    }
}