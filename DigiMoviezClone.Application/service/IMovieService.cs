using DigiMoviezClone.Domain.Entities;

namespace DigiMoviezClone.Application.Services;

public interface IMovieService
{
    Task<Movie> createMovie(Movie movie);
    Task<Movie> findMovie(int id);
    Task<Movie> UpdateMovie(int id, Movie movie);
    Task<Movie> DeleteMovie(int id);
    Task<IEnumerable<Movie>> findAllMovies();
}