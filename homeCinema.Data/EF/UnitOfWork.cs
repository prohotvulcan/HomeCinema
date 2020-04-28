using System.Threading.Tasks;

namespace homeCinema.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HomeCinemaDbContext _dbContext;

        public UnitOfWork(HomeCinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_dbContext != null) _dbContext.Dispose();
        }
    }
}
