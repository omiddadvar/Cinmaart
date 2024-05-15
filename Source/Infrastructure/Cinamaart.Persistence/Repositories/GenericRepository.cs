using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MainDBContext _dbContext;
        public GenericRepository(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task Delete(long id)
        {
            var entity = await Get(id);
            Delete(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await Get(id);
            Delete(entity);
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<bool> Exist(long id, CancellationToken cancellationToken = default)
        {
            var entity = await Get(id, cancellationToken);
            return entity != null;
        }

        public async Task<bool> Exist(int id, CancellationToken cancellationToken = default)
        {
            var entity = await Get(id, cancellationToken);
            return entity != null;
        }

        public async Task<T> Get(long id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task<T> Get(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> Where = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                CancellationToken cancellationToken = default,
                params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (Where != null)
            {
                query = query.Where(Where);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync(cancellationToken);
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Update(long id)
        {
            var entity = await Get(id);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Update(int id)
        {
            var entity = await Get(id);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
