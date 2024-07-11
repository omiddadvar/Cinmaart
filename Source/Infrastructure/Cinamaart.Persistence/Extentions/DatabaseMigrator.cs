using Cinamaart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Extentions
{
    public static class DatabaseMigrator
    {
        public static async Task<IHost> MigrateDebugDatabase(this IHost app, CancellationToken cancellation = default)
        {
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopedFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<MainDBContext>();
                bool isDeleted = await dbContext.Database.EnsureDeletedAsync(cancellation);
                if (!isDeleted) 
                    throw new OperationCanceledException("Database's not deleted successfully.");
                //bool isCreated = await dbContext.Database.EnsureCreatedAsync(cancellation);
                //if (!isCreated)
                //    throw new OperationCanceledException("Database's not created successfully.");
                await dbContext.Database.MigrateAsync(cancellation);
            }
            return app;
        }
    }
}
