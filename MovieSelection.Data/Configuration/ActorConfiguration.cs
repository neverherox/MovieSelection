using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieSelection.Data.Models;

namespace MovieSelection.Data.Configuration
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(200);
        }
    }
}
