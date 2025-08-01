
namespace DigiMoviezClone.API.DTOs
{
    public class CommentDto
    {

        public string Text { get; set; }
        public long MovieId { get; set; }
        public long? ParentCommentId { get; set; } 


    }
}