using AutoMapper;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.API.DTOs.Comment;
using DigiMoviezClone.API.DTOs.Movie;
using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Application.DTOs;
using DigiMoviezClone.Domain.Entities.Genres;
using DigiMoviezClone.Domain.Entities.Comments;
using DigiMoviezClone.Domain.Entities.Movies;

namespace DigiMoviezClone.Application.MappingProfiles
{
    public class GenreProfile : Profile
    {
        
        public GenreProfile()
        {
            CreateMap<Genre, GenreRequestDto>();
            CreateMap<Genre, GenreResponseDto>()
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies));
            CreateMap<Movie, MovieResponseDto>();
            CreateMap<GenreRequestDto, Genre>();
            CreateMap<Genre, GenreWithMoviesDto>()
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Name));
            CreateMap<CommentDto, Comment>();
            
        }

     
        
    }
}