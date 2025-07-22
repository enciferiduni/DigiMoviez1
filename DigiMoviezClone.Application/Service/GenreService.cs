
using DigiMoviezClone.Domain.Entities.Genres;
using DigiMoviezClone.Domain.Entities.Movies;
using DigiMoviezClone.Domain.Interfaces;
using DigiMoviezClone.Domain.Repositories;


namespace DigiMoviezClone.Domain.Entities
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            
            return await _genreRepository.GetAllWithMoviesAsync();
        }

        public async Task<Genre> GetById(long id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
                throw new KeyNotFoundException($"Genre with ID {id} not found.");
            return genre;
        }

        public async Task<Genre> Create(Genre genre)
        {
            return await _genreRepository.AddAsync(genre);
        }

        public async Task<Genre> Update(long id,Genre genre)
        {
            var existingGenre =  await GetById(id);

            existingGenre.Name = genre.Name;
     

            await _genreRepository.UpdateAsync(existingGenre);

            return existingGenre;
        }

        public async  Task<Genre> Delete(long id)
        {
            var existingMovie = await GetById(id);
            return await _genreRepository.DeleteAsync(existingMovie);
        }

        public Task<IEnumerable<Movie>> findAllVahshatnakMovies()
        {
            throw new NotImplementedException();
        }

        
    }
}
