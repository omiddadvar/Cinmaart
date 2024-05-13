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
    internal class TvSerieArtistConfig : IEntityTypeConfiguration<TvSerieArtist>
    {
        public void Configure(EntityTypeBuilder<TvSerieArtist> builder)
        {
            builder.HasOne(t => t.TvSerie)
               .WithMany(e => e.TvSerieArtists)
               .HasForeignKey(t => t.TvSerieId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

            builder.HasOne(t => t.Artist)
                 .WithMany(e => e.TvSerieArtists)
                 .HasForeignKey(t => t.ArtistId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.ToTable(nameof(TvSerieArtist));
        }
    }
}
