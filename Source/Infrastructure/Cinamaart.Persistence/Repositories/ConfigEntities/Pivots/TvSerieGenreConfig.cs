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
    internal class TvSerieGenreConfig : IEntityTypeConfiguration<TvSerieGenre>
    {
        public void Configure(EntityTypeBuilder<TvSerieGenre> builder)
        {
            throw new NotImplementedException();
        }
    }
}
