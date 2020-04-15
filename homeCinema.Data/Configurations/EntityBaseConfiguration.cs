using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace homeCinema.Data.Configurations
{
    public class EntityBaseConfiguration<T> 
        : IEntityTypeConfiguration<T> where T : class, IEntityBase
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
