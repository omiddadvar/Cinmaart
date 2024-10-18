using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cinamaart.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MainDBContext _dbContext;
        public GenericRepository(MainDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await GetAsync(id);
            DeleteAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            DeleteAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<bool> ExistAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await GetAsync(id, cancellationToken);
            return entity != null;
        }

        public async Task<bool> ExistAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await GetAsync(id, cancellationToken);
            return entity != null;
        }

        public async Task<T> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task<T> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(
             Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
             CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<T>> GetAsync(
                Expression<Func<T, bool>>? Where = null,
                Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
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

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(long id)
        {
            var entity = await GetAsync(id);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(int id)
        {
            var entity = await GetAsync(id);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<PagedList<T>> PaginateAsync(
            int page,
            int pageSize,
            Expression<Func<T, bool>> Where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            int totalCount = await query.CountAsync(cancellationToken);

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
                query = orderBy(query);
            }
            return await PagedList<T>.CreateAsync(query, page, pageSize);
        }
    }
}
