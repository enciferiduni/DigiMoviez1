using DigiMoviezClone.Domain.Entities.Comments;
using DigiMoviezClone.Domain.Interfaces;

namespace DigiMoviezClone.API.DTOs;

public interface ICommentService
{
    Task<CommentResponseDto?> GetCommentByIdAsync(long id);
    Task<List<CommentResponseDto>> GetAllCommentsAsync();
    Task UpdateCommentAsync(long id, string newText);
    Task DeleteCommentAsync(long id);
    
    Task<List<CommentResponseDto>> GetCommentsByMovieIdAsync(long movieId);
    Task<List<CommentResponseDto>> GetFlat(long movieId);
    Task<List<CommentResponseDto>> GetTree(long movieId);

    Task AddCommentAsync(CommentDto commentDto, string userId);
    Task AddCommentAsync(CommentDto commentDto);
    
    // New methods for nested replies
    Task<CommentResponseDto> AddReplyAsync(CreateReplyDto replyDto, string userId);
    Task<List<CommentResponseDto>> GetCommentsTreeAsync(long movieId);
}

