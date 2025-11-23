using System.Security.Claims;
using DigiMoviezClone.Domain.Entities.Users;

namespace DigiMoviezClone.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        ClaimsPrincipal? ValidateToken(string token);
    }
}