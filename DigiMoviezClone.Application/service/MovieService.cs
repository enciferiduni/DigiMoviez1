using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.Application.DTOs;

namespace DigiMoviezClone.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private IMovieService _movieServiceImplementation;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task DeleteMovieAsync(int id)
        {
            await _movieRepository.DeleteAsync(id);
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            return await _movieRepository.AddAsync(movie);
        }

        public async Task<Movie> FindMovie(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public Task<Movie> createMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> findMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Movie movie)
        {
            return _movieServiceImplementation.UpdateAsync(movie);
        }

        public Task DeleteAsync(int id)
        {
            return _movieServiceImplementation.DeleteAsync(id);
        }

        public Task AddAsync(CreateMovieRequestDto movie)
        {
            return _movieServiceImplementation.AddAsync(movie);
        }

        public Task<Movie?> GetByIdAsync(int id)
        {
            return _movieServiceImplementation.GetByIdAsync(id);
        }

        public Task<Movie?> GetAllAsync()
        {
            return _movieServiceImplementation.GetAllAsync();
        }
    }
}