using Cinamaart.Domain.Entities.Pivots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Pivots
{
    internal class MovieSubtitleConfig : IEntityTypeConfiguration<MovieSubtitle>
    {
        public void Configure(EntityTypeBuilder<MovieSubtitle> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Movie)
                 .WithMany(e => e.MovieSubtitles)
                 .HasForeignKey(t => t.MovieId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.HasOne(t => t.Subtitle)
                 .WithMany(e => e.MovieSubtitles)
                 .HasForeignKey(t => t.SubtitleId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.ToTable(nameof(MovieSubtitle));
        }
    }
}
