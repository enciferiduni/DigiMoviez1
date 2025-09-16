using DigiMoviezClone.Domain.Entities.Comments;
using DigiMoviezClone.Domain.Entities.Genres;

namespace DigiMoviezClone.Domain.Entities.Movies;

public class Movie
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string? Description { get; set; }

    public long GenreId { get; set; }
    public Genre Genre { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}