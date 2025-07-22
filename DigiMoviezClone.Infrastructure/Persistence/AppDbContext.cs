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

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.Restrict);  
        
        base.OnModelCreating(modelBuilder);
        
    }
  
}