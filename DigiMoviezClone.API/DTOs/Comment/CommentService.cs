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
    private readonly ICommentRepository _repo;

    public CommentService(AppDbContext context, IMapper mapper, ICommentRepository commentRepository,ICommentRepository repo)
    {
        _context = context;
        _mapper = mapper;
        _commentRepository = commentRepository;
        _repo = repo;

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

    public async Task AddCommentAsync(CreateCommentDto dto, string userId)
    {
        var comment = _mapper.Map<Comment>(dto);
        comment.CreatedAt = DateTime.UtcNow;
        comment.UserId = userId;
        await _repo.AddAsync(comment);
    }


public async Task<List<CommentResponseDto>> GetCommentsByMovieIdAsync(long movieId)
    {
        var comments = await _context.Comments
            .Where(c => c.MovieId == movieId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();

        return _mapper.Map<List<CommentResponseDto>>(comments);
        
        var flat = await _repo.GetByMovieIdAsync(movieId);

        List<CommentResponseDto> Build(Comment c)
        {
            var dto = _mapper.Map<CommentResponseDto>(c);
            dto.Replies = flat
                .Where(x => x.ParentCommentId == c.Id)
                .SelectMany(x => Build(x))
                .ToList();
            return new List<CommentResponseDto> { dto };
        }

        var roots = flat.Where(c => c.ParentCommentId == null);
        return roots.SelectMany(c => Build(c)).ToList();
    }
    



}

