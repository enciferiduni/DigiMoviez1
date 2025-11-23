using AutoMapper;
using DigiMoviezClone.Application.DTOs.Users;
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