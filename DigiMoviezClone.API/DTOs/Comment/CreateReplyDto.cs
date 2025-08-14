namespace DigiMoviezClone.API.DTOs
{
    public class CreateReplyDto
    {
        public string Text { get; set; } = string.Empty;
        public long ParentCommentId { get; set; }
    }
} 