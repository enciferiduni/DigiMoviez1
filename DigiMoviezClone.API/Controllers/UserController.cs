
using DigiMoviezClone.API.DTOs.Users;
using DigiMoviezClone.Application.DTOs.User;   
using DigiMoviezClone.Application.Services;
using DigiMoviezClone.Domain.Interfaces; // IUserService از لایه Application
using Microsoft.AspNetCore.Mvc;

namespace DigiMoviezClone.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDto>> Register([FromBody] UserRegisterDto dto)
        {
            try
            {
                var result = await _userService.RegisterAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // مثلاً اگر ایمیل تکراری بود
                return Conflict(new { message = ex.Message });
            }
        }

        // POST: api/user/login
        [HttpPost("login")]
        public async Task<ActionResult<UserResponseDto>> Login([FromBody] UserLoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);
            if (result == null)
                return Unauthorized(new { message = "Invalid email or password." });

            return Ok(result);
        }
    }
}