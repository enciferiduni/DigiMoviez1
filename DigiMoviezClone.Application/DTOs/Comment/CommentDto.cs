namespace DigiMoviezClone.API.DTOs.Comment
{
    public class CommentDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long MovieId { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long? ParentCommentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsEdited { get; set; }
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
        public List<CommentDto> Replies { get; set; } = new List<CommentDto>();
    }
} 