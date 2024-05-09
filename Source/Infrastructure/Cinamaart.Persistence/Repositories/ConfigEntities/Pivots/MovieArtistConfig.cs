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
    internal class MovieArtistConfig : IEntityTypeConfiguration<MovieArtist>
    {
        public void Configure(EntityTypeBuilder<MovieArtist> builder)
        {
            throw new NotImplementedException();
        }
    }
}
