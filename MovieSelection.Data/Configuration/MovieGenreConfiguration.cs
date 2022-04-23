using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieSelection.Data.Models;

namespace MovieSelection.Data.Configuration
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey("MovieId", "GenreId");
        }
    }
}
