using Cinamaart.Domain.Entities.Pivots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Pivots
{
    internal class TvSerieArtistConfig : IEntityTypeConfiguration<TvSerieArtist>
    {
        public void Configure(EntityTypeBuilder<TvSerieArtist> builder)
        {
            builder.HasKey(t => t.Id);
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
