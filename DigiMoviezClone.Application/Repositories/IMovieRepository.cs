using DigiMoviezClone.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiMoviezClone.Domain.longerfaces
{
    public interface IMovieRepository
    {
        Task<Movie?> GetByIdAsync(long id);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task<Movie> DeleteAsync(Movie movie);

    
    }
}