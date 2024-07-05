using AutoMapper.Execution;
using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Common;
using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Seeders
{
    public abstract class BaseEnumSeeder<TEnum,TEntity>(MainDBContext dbContext) : ISeeder
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
