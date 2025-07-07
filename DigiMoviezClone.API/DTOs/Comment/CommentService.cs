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
    public async Task AddCommentAsync(CommentDto commentDto)
    {
        var movie = await _context.Movies.FindAsync(commentDto.MovieId);
        if (movie == null)
            throw new Exception("Movie not found");

        var comment = _mapper.Map<Comment>(commentDto);
        comment.CreatedAt = DateTime.UtcNow;

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
    }

    public async Task<CommentResponseDto?> GetCommentByIdAsync(long id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        if (comment == null) return null;

        return new CommentResponseDto
        {
            Id = comment.Id,
            Text = comment.Text,
            CreatedAt = comment.CreatedAt
        };
    }

    public  async Task<List<CommentResponseDto>> GetAllCommentsAsync()
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
  



}

