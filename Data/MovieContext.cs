using Microsoft.EntityFrameworkCore;
using MoviesAspNetCore.Entities;

namespace MoviesAspNetCore.Data;

public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Actor> Actors => Set<Actor>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasMany(m => m.Actors).WithMany(a => a.Movies);
    }
}