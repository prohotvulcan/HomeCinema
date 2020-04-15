using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace homeCinema.Data.EF
{
    public class HomeCinemaDbContextFactory : IDesignTimeDbContextFactory<HomeCinemaDbContext>
    {
        public HomeCinemaDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("HomeCinema");
            var optionsBuilder = new DbContextOptionsBuilder<HomeCinemaDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new HomeCinemaDbContext(optionsBuilder.Options);
        }
    }
}
