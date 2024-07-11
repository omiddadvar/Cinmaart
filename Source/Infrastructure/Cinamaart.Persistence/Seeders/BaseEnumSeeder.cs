using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Seeders
{
    public abstract class BaseEnumSeeder<TEnum, TEntity>(MainDBContext dbContext) : ISeeder
        where TEnum : Enum
        where TEntity : class, new()
    {
        public abstract uint Order { get; }

        public virtual void Seed()
        {
            // Check if already seeded
            if (dbContext.Set<TEntity>().Any())
                return;

            // Seeding by enum
            var dataList = new List<EnumDataModel>();
            foreach (TEnum enumType in Enum.GetValues(typeof(TEnum)))
            {
                dataList.Add(new EnumDataModel
                {
                    Id = (int)(object)enumType,
                    Name = enumType.ToString()
                });
            }
            var entityData = getPreparedData(dataList);
            dbContext.Set<TEntity>().AddRange(entityData);
            dbContext.SaveChanges();
        }
        protected abstract IList<TEntity> getPreparedData(List<EnumDataModel> enumData);

        protected struct EnumDataModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
