﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        public async Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await (predicate != null
                ? _dbContext.Set<T>().Where(predicate).ToListAsync()
                : _dbContext.Set<T>().ToListAsync());
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, object>> orderByDescPredicate = null, int? take = null)
        {
            var result = _dbContext.Set<T>();
            if (orderByDescPredicate != null)
            {
                result.OrderByDescending(orderByDescPredicate);
            }

            if (take != null)
            {
                result.Take(take.Value);
            }

            return await result.ToListAsync();
        }

        public async Task<T> GetSingleAsync(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Edit(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
