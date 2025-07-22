using DigiMoviezClone.Domain.Entities.Genres;

namespace DigiMoviezClone.Domain.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllWithMoviesAsync();
        Task<Genre> GetByIdAsync(long id);
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> AddAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task<Genre> DeleteAsync(Genre genre);
    }
}