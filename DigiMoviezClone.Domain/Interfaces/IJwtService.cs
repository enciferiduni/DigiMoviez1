using DigiMoviezClone.Domain.Entities.Users;
using System.Security.Claims;

namespace DigiMoviezClone.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        ClaimsPrincipal? ValidateToken(string token);
    }
}