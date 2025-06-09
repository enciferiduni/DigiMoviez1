using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Domain.Interfaces;

namespace DigiMoviezClone.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> createMovie(Movie movie)
        {
            return await _movieRepository.AddAsync(movie);
        }

        public async Task<Movie> findMovie(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> UpdateMovie(int id, Movie movie)
        {
            var existingMovie = await findMovie(id);
            if (existingMovie == null)
            {
                throw new KeyNotFoundException($"Movie with ID {id} not found.");
            }

            // Update only allowed properties (avoid overwriting ID)
            existingMovie.Title = movie.Title;
            existingMovie.Description = movie.Description;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.Genre = movie.Genre;
            // Add other properties as needed

            await _movieRepository.UpdateAsync(existingMovie);

            return existingMovie;
        }


        public async Task<Movie> DeleteMovie(int id)
        {
            var existingMovie = await findMovie(id);
            if (existingMovie == null)
            {
                throw new KeyNotFoundException($"Movie with ID {id} not found.");
            }
            return await _movieRepository.DeleteAsync(existingMovie);
        }

        public Task<Movie?> GetByIdAsync(int id)
        {
            return _movieRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Movie>> findAllMovies()
        {
            return _movieRepository.GetAllAsync();
        }
    }
}