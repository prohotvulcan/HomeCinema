using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace homeCinema.Data.EF
{
    public class BaseRepository<T> : IRepository<T>
        where T : class, IEntityBase, new()
    {
        private readonly HomeCinemaDbContext _dbContext;

        public BaseRepository(HomeCinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }
            return query;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public T GetSingle(int id)
        {
            return _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Edit(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
