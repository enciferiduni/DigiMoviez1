using AutoMapper;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.API.DTOs.Comment;
using DigiMoviezClone.Domain.Entities.CommentReactions;

namespace DigiMoviezClone.Application.MappingProfiles;

public class CommentReactionProfile: Profile
{
    public CommentReactionProfile()
    {
        CreateMap<CommentReaction, CommentReactionDto>().ReverseMap();
    }
}
