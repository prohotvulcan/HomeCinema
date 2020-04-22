namespace homeCinema.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HomeCinemaDbContext _dbContext;

        public UnitOfWork(HomeCinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContext != null) _dbContext.Dispose();
        }
    }
}
