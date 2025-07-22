using DigiMoviezClone.Domain.Entities.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiMoviezClone.Domain.Entities.Genres;

public class Genre
{

    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<Movie> Movies { get; set; }
}

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{

    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasMany(g => g.Movies)
            .WithOne(m => m.Genre)
            .HasForeignKey(m => m.GenreId);
    }
  public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(m => m.ReleaseDate)
            .IsRequired();

        builder.HasMany(m => m.Comments)
            .WithOne(c => c.Movie)
            .HasForeignKey(c => c.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.GenreId)
            .IsRequired();
    }

}

