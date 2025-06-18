namespace DigiMoviezClone.Application.DTOs
{
    public class MovieRequestDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime releaseDate { get; set; }
        public long GenreId { get; set; }
    }
}