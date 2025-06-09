namespace DigiMoviezClone.Application.DTOs
{
    public class UpdateMovieRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public DateTime releaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;
    }
}