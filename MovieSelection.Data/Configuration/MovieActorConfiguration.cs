using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieSelection.Data.Models;

namespace MovieSelection.Data.Configuration
{
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey("MovieId", "ActorId");
        }
    }
}
