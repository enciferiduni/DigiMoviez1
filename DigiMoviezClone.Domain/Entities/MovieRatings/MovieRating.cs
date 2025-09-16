namespace DigiMoviezClone.Domain.Entities.MovieRatings;

public class MovieRating
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public long MovieId { get; set; }
    public int Score { get; set; } 
}