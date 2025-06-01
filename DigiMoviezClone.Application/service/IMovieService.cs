using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.Application.DTOs;
using DigiMoviezClone.Domain.Entities;

namespace DigiMoviezClone.Application.Services;

public interface IMovieService
{
    Task<Movie> createMovie(Movie movie);
    
    Task<Movie> findMovie(int id);
    Task UpdateAsync(Movie movie);
    Task DeleteAsync(int id);
    Task AddAsync(CreateMovieRequestDto movie);
    Task<Movie?> GetByIdAsync(int id);
    Task<Movie?> GetAllAsync();
}