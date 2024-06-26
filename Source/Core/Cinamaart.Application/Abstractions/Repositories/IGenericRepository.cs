﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Get(long id, CancellationToken cancellationToken = default);
        Task<T> Get(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> Where = null, 
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                CancellationToken cancellationToken = default,
                params Expression<Func<T, object>>[] includeProperties);

        Task<bool> Exist(long id, CancellationToken cancellationToken = default);
        Task<bool> Exist(int id, CancellationToken cancellationToken = default);
        Task Update(T entity);
        Task Update(long id);
        Task Update(int id);
        Task Delete(long id);
        Task Delete(int id);
        Task Delete(T entity);

    }
}
