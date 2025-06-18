namespace DigiMoviezClone.API.DTOs.Movie;

public class GenreWithMoviesDto
{
    public long GenreId { get; set; }
    public string GenreName { get; set; }
    public List<MovieDto> Movies { get; set; }
}

