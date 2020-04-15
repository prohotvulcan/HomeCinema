using homeCinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace homeCinema.Data.Configurations
{
    public class MovieConfiguration : EntityBaseConfiguration<Movie>
    {
        public new void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.GenreId).IsRequired();
            builder.Property(p => p.Director).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Writer).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Producer).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Rating).IsRequired();
            builder.Property(p => p.Description).IsRequired().HasMaxLength(2000);
            builder.Property(p => p.TrailerURI).HasMaxLength(200);

            builder.HasOne(x => x.Genre)
                .WithMany(y => y.Movies)
                .HasForeignKey(x => x.GenreId);
        }
    }
}
