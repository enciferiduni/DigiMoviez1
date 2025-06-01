namespace DigiMoviezClone.API.DTOs;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }=string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }   
}