using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories
{
    public class RoleRepository(RoleManager<Role> roleManager) : IRoleRepository
    {
        public async Task<IdentityResult> AddAsync(Role entity, CancellationToken cancellationToken = default)
            => await roleManager.CreateAsync(entity);
        

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken = default) 
            => await roleManager.DeleteAsync(role);


        public async Task<bool> ExistAsync(string roleName, CancellationToken cancellationToken = default)
         => await roleManager.RoleExistsAsync(roleName);
        

        public async Task<IEnumerable<Role>> GetAsync(
            Expression<Func<Role, bool>> Where = null, 
            Func<IQueryable<Role>, IOrderedQueryable<Role>> orderBy = null, 
            CancellationToken cancellationToken = default, 
            params Expression<Func<Role, object>>[] includeProperties)
        {
            IQueryable<Role> query = roleManager.Roles;

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

        public async Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken = default)
            => await roleManager.Roles.ToListAsync(cancellationToken);
        

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken = default)
         => await roleManager.UpdateAsync(role);

    }
}
