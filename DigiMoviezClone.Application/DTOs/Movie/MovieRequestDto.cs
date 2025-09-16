namespace DigiMoviezClone.Application.DTOs.Movie
{
    public class MovieRequestDto
    {
        public string Title { get; set; }=string.Empty;
        public string? Description { get; set; }
        public DateTime releaseDate { get; set; }
        public long GenreId { get; set; }
    }
}