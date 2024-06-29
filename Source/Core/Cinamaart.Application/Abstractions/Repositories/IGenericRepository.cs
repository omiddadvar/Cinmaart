using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> : IRepository
        where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> GetAsync(long id, CancellationToken cancellationToken = default);
        Task<T> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>>? Where = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[] includeProperties);

        Task<bool> ExistAsync(long id, CancellationToken cancellationToken = default);
        Task<bool> ExistAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity);
        Task UpdateAsync(long id);
        Task UpdateAsync(int id);
        Task DeleteAsync(T entity);
        Task DeleteAsync(long id);
        Task DeleteAsync(int id);
        Task<PagedList<T>> PaginateAsync(
            int page,
            int pageSize,
            Expression<Func<T, bool>> Where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includeProperties);
    }
}
