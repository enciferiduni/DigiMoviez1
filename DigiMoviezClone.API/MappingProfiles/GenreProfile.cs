using AutoMapper;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.API.DTOs.Movie;
using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Application.DTOs;

namespace DigiMoviezClone.Application.MappingProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreRequestDto>();
            CreateMap<Genre, GenreResponseDto>();
            CreateMap<GenreRequestDto, Genre>();
            CreateMap<Genre, GenreWithMoviesDto>()
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Name));
        }

     
        
    }
}