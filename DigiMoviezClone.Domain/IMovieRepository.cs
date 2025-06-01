using DigiMoviezClone.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiMoviezClone.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<Movie?> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(int id);
    }
}