using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;
using Cinamaart.Persistence.Seeders;
using Cinamaart.Persistence.Seeders.EntitySeeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Cinamaart.Persistence.Extentions
{
    public static class DataSeeder
    {
        public static IHost SeedData(this IHost app)
        {
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopedFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<MainDBContext>();
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
                _CallAllSeeders(dbContext, userManager);
            }
            return app;
        }
        private static void _CallAllSeeders(MainDBContext dbContext, UserManager<User> userManager)
        {
            var assembly = Assembly.GetAssembly(typeof(MainDBContext));
            var seederClasses = assembly.GetTypes()
                    .Where(t => typeof(ISeeder).IsAssignableFrom(t)
                                && !t.IsInterface
                                && !t.Equals(typeof(BaseEnumSeeder<,>))
                                && !t.Equals(typeof(UserSeeder)))
                    .Select(t => Activator.CreateInstance(t, args: dbContext) as ISeeder)
                    .ToList();

            seederClasses.Add(new UserSeeder(dbContext, userManager));

            seederClasses = seederClasses.OrderBy(s => s.Order).ToList();

            if (seederClasses is not null)
            {
                foreach (var seeder in seederClasses)
                {
                    seeder?.Seed();
                }
            }
        }
    }
}
