using DigiMoviezClone.Application.Configurations;
using DigiMoviezClone.Domain.Entities.Comments;
using DigiMoviezClone.Domain.Entities.Genres;
using DigiMoviezClone.Domain.Entities.Movies;
using Microsoft.EntityFrameworkCore;

namespace DigiMoviezClone.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres { get; set; }
    
    public DbSet<Comment> Comments { get; set; }
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfigurations()); 

        
        base.OnModelCreating(modelBuilder);
    }
  
}