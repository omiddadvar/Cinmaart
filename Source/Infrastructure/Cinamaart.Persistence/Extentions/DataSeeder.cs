using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;
using Cinamaart.Persistence.Seeders;
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
                _CallAllSeeders(dbContext);
            }
            return app;
        }
        private static void _CallAllSeeders(MainDBContext dbContext)
        {
            var assembly = Assembly.GetAssembly(typeof(MainDBContext));
            var seederClasses = assembly.GetTypes()
                    .Where(t => typeof(ISeeder).IsAssignableFrom(t)
                                && !t.IsInterface
                                && !t.Equals(typeof(BaseEnumSeeder<,>)))
                    .Select(t => Activator.CreateInstance(t, args: dbContext) as ISeeder)
                    .OrderBy(s => s.Order)
                    .ToArray();

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
