using DigiMoviezClone.Domain.Entities.Comments;
using DigiMoviezClone.Domain.Repositories;
using DigiMoviezClone.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DigiMoviezClone.Infrastructure;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Comment>> GetByMovieIdAsync(long movieId)
    {
        return await _context.Comments
            .Where(c => c.MovieId == movieId)
            .ToListAsync();
    }
    
    
    public async Task<Comment?> GetByIdAsync(long id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async Task UpdateAsync(Comment comment)
    {
        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Comment id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }


    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

}