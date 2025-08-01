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
            .OrderBy(c => c.CreatedAt)
            .OrderBy(c => c.CreatedAt)
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

    public async Task DeleteAsync(Comment comment)
    {
        var commentToDelete = await _context.Comments.FindAsync(comment.Id);
        if (commentToDelete != null)
        {
            _context.Comments.Remove(commentToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    // New methods for nested replies
    public async Task<List<Comment>> GetCommentsTreeAsync(long movieId)
    {
        // Get all comments for the movie
        var allComments = await _context.Comments
            .Where(c => c.MovieId == movieId)
            .Include(c => c.Replies)
            .ToListAsync();

        // Build the tree structure recursively
        var rootComments = allComments.Where(c => c.ParentCommentId == null).ToList();
        
        foreach (var comment in rootComments)
        {
            BuildRepliesTree(comment, allComments);
        }

        return rootComments.OrderByDescending(c => c.CreatedAt).ToList();
    }

    private void BuildRepliesTree(Comment parentComment, List<Comment> allComments)
    {
        var replies = allComments.Where(c => c.ParentCommentId == parentComment.Id).ToList();
        parentComment.Replies = replies.OrderBy(c => c.CreatedAt).ToList();
        
        foreach (var reply in replies)
        {
            BuildRepliesTree(reply, allComments);
        }
    }

    public async Task<Comment?> GetCommentWithRepliesAsync(long commentId)
    {
        return await _context.Comments
            .Include(c => c.Replies)
            .FirstOrDefaultAsync(c => c.Id == commentId);
    }
}