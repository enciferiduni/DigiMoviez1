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

    Task AddCommentAsync(CommentDto commentDto, string userId);
    
    // New methods for nested replies
    Task<CommentResponseDto> AddReplyAsync(CreateReplyDto replyDto, string userId);
    Task<CommentResponseDto> AddReplyWithMovieValidationAsync(CreateReplyDto replyDto, long expectedMovieId, string userId);
}

