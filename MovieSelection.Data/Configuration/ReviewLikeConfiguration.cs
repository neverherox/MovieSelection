using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieSelection.Models.Entities;

namespace MovieSelection.Data.Configuration
{
    public class ReviewLikeConfiguration : IEntityTypeConfiguration<ReviewLike>
    {
        public void Configure(EntityTypeBuilder<ReviewLike> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
