using Cinamaart.Domain.Abstractions;
using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Seeders
{
    public abstract class BaseEnumSeeder<TEnum, TEntity>(MainDBContext dbContext) : ISeeder
        where TEnum : Enum
        where TEntity : class, IBaseTypeEntity, new()
    {
        public abstract uint Order { get; }

        public virtual void Seed()
        {
            // Check if already seeded
            if (dbContext.Set<TEntity>().Any())
                return;

            // Seeding by enum
            var dataList = new List<TEntity>();
            foreach (TEnum enumType in Enum.GetValues(typeof(TEnum)))
            {
                dataList.Add(new TEntity
                {
                    Id = (int)(object)enumType,
                    Name = enumType.ToString()
                });
            }
            dbContext.Set<TEntity>().AddRange(dataList);
            dbContext.SaveChanges();
        }
    }
}
