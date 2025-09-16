using AutoMapper;
using DigiMoviezClone.Application.DTOs.Users;
using DigiMoviezClone.Domain.Entities.Users;
using DigiMoviezClone.Domain.Interfaces;
using DigiMoviezClone.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DigiMoviezClone.Application.Services
{
    public class UserService : IUserService
    {
        
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public UserService(AppDbContext context, IMapper mapper, IJwtService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<UserResponseDto> RegisterAsync(UserRegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                throw new Exception("Email is already registered.");

            var user = _mapper.Map<User>(dto);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<UserResponseDto>(user);
            response.Token = _jwtService.GenerateToken(user);

            return response;
        }

        public async Task<UserResponseDto?> LoginAsync(UserLoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            var response = _mapper.Map<UserResponseDto>(user);
            response.Token = _jwtService.GenerateToken(user);

            return response;
        }
    }
}