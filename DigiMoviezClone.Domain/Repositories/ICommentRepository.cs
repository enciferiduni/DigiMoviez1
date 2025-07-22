using DigiMoviezClone.Domain.Entities.Comments;

namespace DigiMoviezClone.Domain.Repositories;

public interface ICommentRepository
{
    Task AddAsync(Comment comment);
    Task<List<Comment>> GetByMovieIdAsync(long movieId);
    Task<Comment?>  GetByIdAsync(long id);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(Comment comment);
    Task<List<Comment>> GetAllAsync(); 
   

}
