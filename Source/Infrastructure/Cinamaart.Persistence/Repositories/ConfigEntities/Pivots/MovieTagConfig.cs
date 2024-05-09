using Cinamaart.Domain.Entities.Pivots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Pivots
{
    internal class MovieTagConfig : IEntityTypeConfiguration<MovieTag>
    {
        public void Configure(EntityTypeBuilder<MovieTag> builder)
        {
            throw new NotImplementedException();
        }
    }
}
