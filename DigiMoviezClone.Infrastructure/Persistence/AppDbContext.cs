using DigiMoviezClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigiMoviezClone.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Movie> Movies => Set<Movie>();
}