
namespace DigiMoviezClone.API.DTOs.Comment
{
    public class CreateCommentDto
    {
        public string Text { get; set; }
        public long MovieId { get; set; }
        public long? ParentCommentId { get; set; }
    }
}