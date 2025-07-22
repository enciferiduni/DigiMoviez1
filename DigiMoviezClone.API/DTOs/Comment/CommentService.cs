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
    private ICommentService _commentServiceImplementation;

    public CommentService(AppDbContext context, IMapper mapper, ICommentRepository commentRepository,ICommentRepository repo)
    {
        _context = context;
        _mapper = mapper;
        _commentRepository = commentRepository;
        _repo = repo;

    }

    public Task AddCommentAsync(CommentDto commentDto, string userId)
    {
        throw new NotImplementedException();
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

    public Task AddCommentAsync(CreateCommentDto dto, string userId)
    {
        throw new NotImplementedException();
    }


    public async Task<List<CommentResponseDto>> GetCommentsByMovieIdAsync(long movieId)
    {
        var comments = await _context.Comments
            .Where(c => c.MovieId == movieId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();

        return _mapper.Map<List<CommentResponseDto>>(comments);

    }

    public async Task<List<CommentResponseDto>> GetTree(long movieId)
    {
        var flatEntities = await _repo.GetByMovieIdAsync(movieId);
        var allDtos = _mapper.Map<List<CommentResponseDto>>(flatEntities);

        CommentResponseDto BuildTree(CommentResponseDto dto)
        {
            dto.Replies = allDtos
                .Where(x => x.ParentCommentId == dto.Id)
                .Select(BuildTree)
                .ToList();
            return dto;
        }

        var roots = allDtos
            .Where(x => x.ParentCommentId == null)
            .ToList();

        return roots.Select(BuildTree).ToList();
    }

    public Task AddCommentAsync(CommentDto commentDto)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CommentResponseDto>> GetFlat(long movieId)
    {
        var flatEntities = await _repo.GetByMovieIdAsync(movieId);
        return _mapper.Map<List<CommentResponseDto>>(flatEntities);
        
    }
}



