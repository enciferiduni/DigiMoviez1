using DigiMoviezClone.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiMoviezClone.Domain.longerfaces
{
    public interface IGenreRepository
    {
        Task<Genre?> GetByIdAsync(long id);
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> AddAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task<Genre> DeleteAsync(Genre genre);
    }
}