using DigiMoviezClone.API.Controllers; 
using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Domain.longerfaces;

namespace DigiMoviezClone.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreService _genreService;

        public MovieService(IMovieRepository movieRepository, IGenreService genreService)
        {
            _movieRepository = movieRepository;
            _genreService = genreService;
        }

        public Task<IEnumerable<Movie>> GetAll()
        {
            return _movieRepository.GetAllAsync();
        }

        public async Task<Movie> GetById(long id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
                throw new KeyNotFoundException($"Movie with ID {id} not found.");
            return movie;
        }

        public async Task<Movie> Create(Movie movie)
        {
            Genre genre = _genreService.GetById(movie.GenredId).Result;
            movie.Genre = genre;
            return await _movieRepository.AddAsync(movie);
        }

        public async Task<Movie> Update(long id, Movie movie)
        {
            var existingMovie =  await GetById(id);

            existingMovie.Title = movie.Title;
            existingMovie.Description = movie.Description;
            existingMovie.ReleaseDate = movie.ReleaseDate;

            await _movieRepository.UpdateAsync(existingMovie);

            return existingMovie;
        }

        public async  Task<Movie> Delete(long id)
        {
            var existingMovie = await GetById(id);
            return await _movieRepository.DeleteAsync(existingMovie);
        }

        public Task<IEnumerable<Movie>> findAllVahshatnakMovies()
        {
            throw new NotImplementedException();
        }
    }
}
