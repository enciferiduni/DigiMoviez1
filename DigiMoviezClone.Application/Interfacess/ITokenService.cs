using DigiMoviezClone.Domain.Entities.Users;

namespace DigiMoviezClone.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}