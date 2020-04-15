using homeCinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace homeCinema.Data.Configurations
{
    public class ErrorConfiguration : EntityBaseConfiguration<Error>
    {
        public new void Configure(EntityTypeBuilder<Error> builder)
        {
            builder.ToTable("Errors");
        }
    }
}
