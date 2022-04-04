using Microsoft.EntityFrameworkCore;
using MovieSelection.Data.Models;

namespace MovieSelection.Data.Context;

public class MovieSelectionContext : DbContext
{
    public MovieSelectionContext()
    {
    }

    public MovieSelectionContext(DbContextOptions<MovieSelectionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; } = null!;
    public virtual DbSet<Country> Countries { get; set; } = null!;
    public virtual DbSet<Genre> Genres { get; set; } = null!;
    public virtual DbSet<Movie> Movies { get; set; } = null!;
    public virtual DbSet<MovieActor> MovieActors { get; set; } = null!;
    public virtual DbSet<MovieGenre> MovieGenres { get; set; } = null!;
    public virtual DbSet<MovieSubscription> MovieSubscriptions { get; set; } = null!;
    public virtual DbSet<Rate> Rates { get; set; } = null!;
    public virtual DbSet<Review> Reviews { get; set; } = null!;
    public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.ToTable("Actor");

            entity.Property(e => e.FirstName).HasMaxLength(100);

            entity.Property(e => e.LastName).HasMaxLength(200);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("Movie");

            entity.Property(e => e.Description).HasMaxLength(1000);

            entity.Property(e => e.Name).HasMaxLength(350);
        });

        modelBuilder.Entity<MovieActor>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("MovieActor");
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("MovieGenre");
        });

        modelBuilder.Entity<MovieSubscription>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("MovieSubscription");
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.ToTable("Rate");

            entity.Property(e => e.Actors).HasColumnType("decimal(3, 1)");

            entity.Property(e => e.Directing).HasColumnType("decimal(3, 1)");

            entity.Property(e => e.Entertainment).HasColumnType("decimal(3, 1)");

            entity.Property(e => e.Plot).HasColumnType("decimal(3, 1)");

            entity.Property(e => e.Value).HasColumnType("decimal(3, 1)");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");

            entity.Property(e => e.Text).HasMaxLength(1000);
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.ToTable("Subscription");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });
    }
}