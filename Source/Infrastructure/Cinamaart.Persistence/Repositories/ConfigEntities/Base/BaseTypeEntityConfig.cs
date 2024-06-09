using Cinamaart.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Base
{
    internal class BaseTypeEntityConfig : IEntityTypeConfiguration<BaseTypeEntity>
    {
        public void Configure(EntityTypeBuilder<BaseTypeEntity> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Ignore(e => e);
        }
    }
}
