using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieSelection.Data.Models;

namespace MovieSelection.Data.Configuration
{
    public class MovieImageConfiguration : IEntityTypeConfiguration<MovieImage>
    {
        public void Configure(EntityTypeBuilder<MovieImage> builder)
        {
            builder.HasKey(x => x.MovieId);
            builder.Property(x => x.MovieId).ValueGeneratedNever();
        }
    }
}
