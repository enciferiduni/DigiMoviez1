using AutoMapper;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Domain.Entities.Comments;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CommentDto, Comment>();
        CreateMap<Comment, CommentResponseDto>()
            .ForMember(dest => dest.Replies, opt => opt.MapFrom(src => src.Replies));
    }
}

