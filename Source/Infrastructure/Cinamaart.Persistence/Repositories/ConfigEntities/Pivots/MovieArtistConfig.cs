using Cinamaart.Domain.Entities.Pivots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Pivots
{
    internal class MovieArtistConfig : IEntityTypeConfiguration<MovieArtist>
    {
        public void Configure(EntityTypeBuilder<MovieArtist> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Movie)
             .WithMany(e => e.MovieArtists)
             .HasForeignKey(t => t.MovieId)
             .OnDelete(DeleteBehavior.Cascade)
             .IsRequired();

            builder.HasOne(t => t.Artist)
                 .WithMany(e => e.MovieArtists)
                 .HasForeignKey(t => t.ArtistId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.ToTable(nameof(MovieArtist));
        }
    }
}
