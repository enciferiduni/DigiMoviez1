namespace DigiMoviezClone.Application.DTOs
{
    public class GenreRequestDto
    {
        public GenreRequestDto(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}