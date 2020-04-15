using homeCinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace homeCinema.Data.Configurations
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        public new void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(200);
            builder.Property(p => p.HashedPassword).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Salt).IsRequired().HasMaxLength(200);
            builder.Property(p => p.IsLocked).IsRequired();
        }
    }
}
