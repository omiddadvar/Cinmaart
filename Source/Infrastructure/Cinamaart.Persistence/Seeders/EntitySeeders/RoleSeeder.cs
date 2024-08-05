using Cinamaart.Application.Abstractions.Constants;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    public class RoleSeeder(MainDBContext dbContext) : ISeeder
    {
        public uint Order => 4;

        public void Seed()
        {
            Type type = typeof(RoleNames);
            var roles = new List<Role>();
            string? tempRoleName;
            foreach (var p in type.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                tempRoleName = p.GetValue(null)?.ToString() ?? null;
                if(tempRoleName is not null)
                roles.Add(new Role
                {
                    NormalizedName = tempRoleName,
                    Name = tempRoleName
                });
            }
            dbContext.Roles.AddRange(roles);
            dbContext.SaveChanges();
        }
    }
}
