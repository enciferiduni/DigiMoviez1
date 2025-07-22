
namespace DigiMoviezClone.API.DTOs
{
    public class CommentResponseDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }               // شناسایی کاربر نویسنده
        public long? ParentCommentId { get; set; }       // برای ریپلای
        public List<CommentResponseDto> Replies { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }
}
