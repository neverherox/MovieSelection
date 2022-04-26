using Microsoft.EntityFrameworkCore;
using MovieSelection.Data.Configuration;
using MovieSelection.Models;

namespace MovieSelection.Data.Context;

public class MovieSelectionContext : DbContext
{
    public MovieSelectionContext()
    {
            
    }

    public MovieSelectionContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=EPBYGROW00E8;Initial Catalog=MovieSelection;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ActorConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        modelBuilder.ApplyConfiguration(new MovieActorConfiguration());
        modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
        modelBuilder.ApplyConfiguration(new RateConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieActor> MovieActors { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }
}