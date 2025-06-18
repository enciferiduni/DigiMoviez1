using DigiMoviezClone.Application.Services;
using DigiMoviezClone.Domain.Entities;
using DigiMoviezClone.Domain.longerfaces;
using DigiMoviezClone.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DigiMoviezClone.Infrastructure.Repositories
{
    public class EfGenreRepository : IGenreRepository 
    {
        private readonly AppDbContext _context;
        private IGenreRepository _genreRepositoryImplementation;
   

        public EfGenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task UpdateAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }


      
        public async Task<Genre> DeleteAsync(Genre genre)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
        

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> AddAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
        public async Task<Genre?> GetByIdAsync(long id)
        {
            return await _context.Genres.FindAsync(id); 
        }



    }
}