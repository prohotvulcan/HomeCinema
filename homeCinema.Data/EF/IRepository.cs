using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace homeCinema.Data.EF
{
    public interface IRepository<T> 
        where T : class, IEntityBase, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAllAsync(Expression<Func<T, object>> orderByDescPredicate = null, int? take = null);
        Task<T> GetSingleAsync(int id);
        Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
    }
}
