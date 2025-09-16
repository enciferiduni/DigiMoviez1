
using DigiMoviezClone.Infrastructure.Persistence;
using AutoMapper;
using DigiMoviezClone.Domain.Repositories;
using DigiMoviezClone.Domain.Interfaces;
using DigiMoviezClone.Domain.Entities.Genres;
using DigiMoviezClone.Domain.Entities.Movies;

namespace DigiMoviezClone.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreService _genreService;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IGenreService genreService, AppDbContext context, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _genreService = genreService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _movieRepository.GetAllAsync();
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
            Genre genre = await _genreService.GetById(movie.GenreId);
            movie.Genre = genre;
            return await _movieRepository.AddAsync(movie);
        }

        public async Task<Movie> Update(long id, Movie movie)
        {
            var existingMovie = await GetById(id);

            existingMovie.Title = movie.Title;
            existingMovie.Description = movie.Description;
            existingMovie.ReleaseDate = movie.ReleaseDate;

            await _movieRepository.UpdateAsync(existingMovie);

            return existingMovie;
        }

        public async Task<Movie> Delete(long id)
        {
            var existingMovie = await GetById(id);
            return await _movieRepository.DeleteAsync(existingMovie);
        }
    }
}
