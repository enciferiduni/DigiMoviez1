using DigiMoviezClone.Domain.Entities.Comments;
using DigiMoviezClone.Domain.Entities.Genres;
using DigiMoviezClone.Domain.Entities.Movies;
using DigiMoviezClone.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using DigiMoviezClone.Infrastructure.Configurations;

namespace DigiMoviezClone.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres { get; set; }
    
    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration()); 
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}