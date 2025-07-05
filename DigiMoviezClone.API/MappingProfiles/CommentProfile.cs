using AutoMapper;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Domain.Entities.Comments;
using static DigiMoviezClone.API.DTOs.CommentDto;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CommentDto, Comment>();
        CreateMap<Comment, CommentResponseDto>();
    }
}