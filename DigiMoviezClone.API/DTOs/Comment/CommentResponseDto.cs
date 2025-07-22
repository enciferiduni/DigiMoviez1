
namespace DigiMoviezClone.API.DTOs
{
    public class CommentResponseDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? ParentCommentId { get; set; }

        public List<CommentResponseDto> Replies { get; set; } = new List<CommentResponseDto>();
    }

}
