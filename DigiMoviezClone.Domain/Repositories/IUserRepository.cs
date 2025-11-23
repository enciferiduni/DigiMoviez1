using DigiMoviezClone.Domain.Entities.Users;

namespace DigiMoviezClone.Domain.Repositories;

public interface  IUserRepository
{

    Task<bool> EmailExistsAsync(string email);
    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);
}