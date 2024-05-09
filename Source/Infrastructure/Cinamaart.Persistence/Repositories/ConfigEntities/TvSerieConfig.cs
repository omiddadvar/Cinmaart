using Cinamaart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories.ConfigEntities
{
    internal class TvSerieConfig : IEntityTypeConfiguration<TvSerie>
    {
        public void Configure(EntityTypeBuilder<TvSerie> builder)
        {
            throw new NotImplementedException();
        }
    }
}
