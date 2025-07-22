namespace DigiMoviezClone.API.DTOs;

public class CreateCommentDto
{
       public long MovieId { get; set; }
       public string Text { get; set; }
       public long? ParentCommentId { get; set; }  
}
