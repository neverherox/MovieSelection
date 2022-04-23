using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieSelection.Data.Models;

namespace MovieSelection.Data.Configuration
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
