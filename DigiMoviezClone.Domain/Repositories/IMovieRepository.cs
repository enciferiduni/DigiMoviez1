using DigiMoviezClone.Domain.Entities.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigiMoviezClone.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> GetByIdAsync(long id);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task<Movie> DeleteAsync(Movie movie);


    }
}