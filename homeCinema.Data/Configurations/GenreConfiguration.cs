using homeCinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace homeCinema.Data.Configurations
{
    public class GenreConfiguration : EntityBaseConfiguration<Genre>
    {
        public new void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}
