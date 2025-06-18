namespace DigiMoviezClone.Domain.Entities;

public class Movie
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string? Description { get; set; }
    
    public long GenredId { get; set; }
    public Genre Genre { get; set; }
   
}