using DigiMoviezClone.API.Controllers;
using DigiMoviezClone.Domain.Entities;

namespace DigiMoviezClone.Application.Services;

public interface IMovieService : IBaseServise<Movie>
{
    Task<IEnumerable<Movie>> findAllVahshatnakMovies();
}