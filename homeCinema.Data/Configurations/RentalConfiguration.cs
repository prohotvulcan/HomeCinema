using homeCinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace homeCinema.Data.Configurations
{
    public class RentalConfiguration : EntityBaseConfiguration<Rental>
    {
        public new void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("Rentals");
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.StockId).IsRequired();
            builder.Property(p => p.Status).IsRequired().HasMaxLength(10);

            builder.HasOne(x => x.Customer)
                .WithMany(y => y.Rentals)
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Stock)
                .WithMany(y => y.Rentals)
                .HasForeignKey(x => x.StockId);
        }
    }
}
