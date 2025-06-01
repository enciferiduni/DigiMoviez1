namespace DigiMoviezClone.Application.DTOs
{
    public class CreateMovieRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public DateTime releaseDate { get; set; }
    }
}