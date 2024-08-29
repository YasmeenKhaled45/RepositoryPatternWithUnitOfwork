using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUnitOfwork.Core.Constant;
using RepositoryPatternWithUnitOfwork.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitofWork.EF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDBcontext _dbcontext;

        public GenericRepository(AppDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbcontext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbcontext.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public int Count()
        {
            return _dbcontext.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _dbcontext.Set<T>().Count(criteria);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await _dbcontext.Set<T>().CountAsync(criteria);
        }

        public void Delete(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbcontext.Set<T>().RemoveRange(entities);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _dbcontext.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _dbcontext.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(criteria).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int skip, int take)
        {
            return await _dbcontext.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take, Expression<Func<T, object>> orderBy = null, string orderByDirection = null)
        {
            IQueryable<T> query = _dbcontext.Set<T>().Where(criteria);
            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public T Update(T entity)
        {
            _dbcontext.Update(entity);
            return entity;
        }
    }
}
