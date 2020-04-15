using homeCinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace homeCinema.Data.Configurations
{
    public class CustomerConfiguration : EntityBaseConfiguration<Customer>
    {
        public new void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.IdentityCard).IsRequired().HasMaxLength(50);
            builder.Property(p => p.UniqueKey).IsRequired();
            builder.Property(p => p.Mobile).HasMaxLength(10);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(200);
        }
    }
}
