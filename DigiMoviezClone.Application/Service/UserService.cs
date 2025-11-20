using DigiMoviezClone.Domain.Repositories;
using DigiMoviezClone.Application.DTOs.Users;
using DigiMoviezClone.Application.Interfaces;
using DigiMoviezClone.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using DigiMoviezClone.Domain.Interfaces;

namespace DigiMoviezClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher,
            ITokenService tokenService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> RegisterAsync(UserRegisterDto dto)
        {
            if (await _userRepository.EmailExistsAsync(dto.Email))
                throw new Exception("Email is already registered.");

            var user = _mapper.Map<User>(dto);
            user.Id = Guid.NewGuid().ToString();
            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            await _userRepository.AddAsync(user);

            var response = _mapper.Map<UserResponseDto>(user);
            response.Token = _tokenService.CreateToken(user);
            return response;
        }

        public async Task<UserResponseDto?> LoginAsync(UserLoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null) return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed) return null;

            var response = _mapper.Map<UserResponseDto>(user);
            response.Token = _tokenService.CreateToken(user);
            return response;
        }
    }
}