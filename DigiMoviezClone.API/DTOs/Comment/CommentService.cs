using DigiMoviezClone.Infrastructure.Persistence;
using AutoMapper;
using DigiMoviezClone.Domain.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using DigiMoviezClone.API.DTOs;

public class CommentService : ICommentService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CommentService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
    public async Task<List<CommentResponseDto>> GetCommentsByMovieIdAsync(long movieId)
    {
        var comments = await _context.Comments
            .Where(c => c.MovieId == movieId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();

        return _mapper.Map<List<CommentResponseDto>>(comments);
    }


}

