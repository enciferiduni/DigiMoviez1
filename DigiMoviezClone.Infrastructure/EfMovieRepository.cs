using DigiMoviezClone.Domain.Entities.Movies;
using DigiMoviezClone.Domain.Repositories;
using DigiMoviezClone.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DigiMoviezClone.Infrastructure.Repositories
{
    public class EfMovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public EfMovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> DeleteAsync(Movie movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> GetByIdAsync(long id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }
    }
}