using DigiMoviezClone.Domain.Entities.Comments;

namespace DigiMoviezClone.Domain.Entities.CommentReactions;

public class CommentReaction
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long commentId { get; set; } 
    public bool IsLike { get; set; }
    
    public Comment Comment { get; set; }
    
}


