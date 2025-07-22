using DigiMoviezClone.Domain.Entities.Comments;
using DigiMoviezClone.Domain.Interfaces;

namespace DigiMoviezClone.API.DTOs;


public interface ICommentService
{

    Task AddCommentAsync(CommentDto commentDto, string userId);
    Task<CommentResponseDto?> GetCommentByIdAsync(long id);
    Task<List<CommentResponseDto>> GetAllCommentsAsync();
    Task UpdateCommentAsync(long id, string newText);
    Task DeleteCommentAsync(long id);
    
    Task AddCommentAsync(CreateCommentDto dto, string userId);
    
    Task<List<CommentResponseDto>> GetCommentsByMovieIdAsync(long movieId);
    
    Task<List<CommentResponseDto>> GetFlat(long movieId);
    Task<List<CommentResponseDto>> GetTree(long movieId);

    Task AddCommentAsync(CommentDto commentDto);
}

