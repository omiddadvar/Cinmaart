using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Abstractions.Repositories
{
    public interface IRoleRepository : IRepository
    {
        Task<IdentityResult> AddAsync(Role entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Role>> GetAsync(Expression<Func<Role, bool>> Where = null,
                Func<IQueryable<Role>, IOrderedQueryable<Role>> orderBy = null,
                CancellationToken cancellationToken = default,
                params Expression<Func<Role, object>>[] includeProperties);

        Task<bool> ExistAsync(string roleName, CancellationToken cancellationToken = default);
        Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken = default);
        Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken = default);
    }
}
