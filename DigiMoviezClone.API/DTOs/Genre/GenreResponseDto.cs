namespace DigiMoviezClone.API.DTOs;

public class GenreResponseDto
{
  public long Id { get; set; }
  public string Name { get; set; }
  // TODO : implement list of movie response dtos here
  public List<MovieResponseDto> Movies { get; set; } = new();

}