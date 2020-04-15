using homeCinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace homeCinema.Data.Configurations
{
    public class StockConfiguration : EntityBaseConfiguration<Stock>
    {
        public new void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");
            builder.Property(p => p.MovieId).IsRequired();
            builder.Property(p => p.UniqueKey).IsRequired();
            builder.Property(p => p.IsAvailable).IsRequired();

            builder.HasOne(x => x.Movie)
                .WithMany(y => y.Stocks)
                .HasForeignKey(x => x.MovieId);
        }
    }
}
