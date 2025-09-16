namespace DigiMoviezClone.API.DTOs.Comment;

public class CommentReactionDto
{
    public long CommentId { get; set; }
    public bool IsLiked { get; set; }
    
}

public class CommentReactionResultDto
{
    public long CommentId { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
}