using Cinamaart.Application.Abstractions.Constants;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    public class UserSeeder(MainDBContext dbContext, UserManager<User> userManager) : ISeeder
    {
        public uint Order => 5;

        public void Seed()
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var admin = dbContext.Users.AsNoTracking().FirstOrDefault(u => u.UserName.Equals("admin"));
                    if (admin is null)
                    {
                        var adminUser = new User
                        {
                            FirstName = "admin",
                            LastName = "administrator",
                            UserName = "admin",
                            Email = "admin.cinamaart@gmail.com"
                        };
                        var result = userManager.CreateAsync(adminUser, "Admin@123").Result;
                        if (result.Succeeded)
                        {
                            var roleResult = userManager.AddToRoleAsync(adminUser, RoleNames.Administrator).Result;
                        }
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }

            }
        }
    }
}
