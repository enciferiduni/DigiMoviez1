using AutoMapper;
using DigiMoviezClone.API.DTOs.Users;
using DigiMoviezClone.Application.DTOs.User;
using DigiMoviezClone.Domain.Entities.Users;

namespace DigiMoviezClone.Application.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserRegisterDto, User>();
        CreateMap<User, UserResponseDto>();
    }
}