using DigiMoviezClone.Infrastructure.Persistence;
using AutoMapper;
using DigiMoviezClone.Domain.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using DigiMoviezClone.API.DTOs;
using DigiMoviezClone.Domain.Repositories;

public class CommentService : ICommentService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICommentRepository _commentRepository;
    

    public CommentService(AppDbContext context, IMapper mapper, ICommentRepository commentRepository)
    {
        _context = context;
        _mapper = mapper;
        _commentRepository = commentRepository;

    }


    public async Task<CommentResponseDto?> GetCommentByIdAsync(long id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        if (comment == null) return null;

        return new CommentResponseDto
        {
            Id = comment.Id,
            Text = comment.Text,
            CreatedAt = comment.CreatedAt,
            ParentCommentId = comment.ParentCommentId,
            Replies = new List<CommentResponseDto>()
        };
    }

    public async Task<List<CommentResponseDto>> GetAllCommentsAsync()
    {

        var comments = await _commentRepository.GetAllAsync();
        return _mapper.Map<List<CommentResponseDto>>(comments);
    }

    public async Task UpdateCommentAsync(long id, string newText)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        if (comment == null)
            throw new Exception("Comment not found");

        comment.Text = newText;
        await _commentRepository.UpdateAsync(comment);
    }


    public async Task DeleteCommentAsync(long id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        if (comment == null)
            throw new Exception("Comment not found");

        await _commentRepository.DeleteAsync(comment);
    }

    public async Task<List<CommentResponseDto>> GetCommentsByMovieIdAsync(long movieId)
    {
        var comments = await _context.Comments
            .Where(c => c.MovieId == movieId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();

        return _mapper.Map<List<CommentResponseDto>>(comments);

    }

    

    public async Task AddCommentAsync(CommentDto commentDto, string userId)
    {
        var movie = await _context.Movies.FindAsync(commentDto.MovieId);
        if (movie == null)
            throw new Exception("Movie not found");

        var comment = _mapper.Map<Comment>(commentDto);
        comment.CreatedAt = DateTime.UtcNow;
        comment.UserId = userId;

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
    }

    


    

    // New methods for nested replies
    public async Task<CommentResponseDto> AddReplyAsync(CreateReplyDto replyDto, string userId)
    {
        // Get the parent comment to ensure it exists and get its MovieId
        var parentComment = await _commentRepository.GetByIdAsync(replyDto.ParentCommentId);
        if (parentComment == null)
            throw new Exception("Parent comment not found");

        var reply = new Comment
        {
            Text = replyDto.Text,
            MovieId = parentComment.MovieId, // Ensure reply belongs to same movie
            ParentCommentId = replyDto.ParentCommentId,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        await _commentRepository.AddAsync(reply);

        return new CommentResponseDto
        {
            Id = reply.Id,
            Text = reply.Text,
            CreatedAt = reply.CreatedAt,
            ParentCommentId = reply.ParentCommentId,
            Replies = new List<CommentResponseDto>()
        };
    }

    // Enhanced method with movie validation
    public async Task<CommentResponseDto> AddReplyWithMovieValidationAsync(CreateReplyDto replyDto, long expectedMovieId, string userId)
    {
        // Get the parent comment to ensure it exists and validate movie
        var parentComment = await _commentRepository.GetByIdAsync(replyDto.ParentCommentId);
        if (parentComment == null)
            throw new Exception("Parent comment not found");

        // Validate that the parent comment belongs to the expected movie
        if (parentComment.MovieId != expectedMovieId)
        {
            throw new Exception($"Reply cannot be added to comment from movie {parentComment.MovieId}. Expected movie {expectedMovieId}.");
        }

        var reply = new Comment
        {
            Text = replyDto.Text,
            MovieId = parentComment.MovieId, // Ensure reply belongs to same movie
            ParentCommentId = replyDto.ParentCommentId,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        await _commentRepository.AddAsync(reply);

        return new CommentResponseDto
        {
            Id = reply.Id,
            Text = reply.Text,
            CreatedAt = reply.CreatedAt,
            ParentCommentId = reply.ParentCommentId,
            Replies = new List<CommentResponseDto>()
        };
    }

    

    // Alternative method using the existing GetTree logic
  
}



