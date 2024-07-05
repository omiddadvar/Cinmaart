using Cinamaart.Domain.Entities.Pivots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Pivots
{
    internal class EpisodeSubtitleConfig : IEntityTypeConfiguration<EpisodeSubtitle>
    {
        public void Configure(EntityTypeBuilder<EpisodeSubtitle> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Episode)
                 .WithMany(e => e.EpisodeSubtitles)
                 .HasForeignKey(t => t.EpisodeId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.HasOne(t => t.Subtitle)
                 .WithMany(e => e.EpisodeSubtitles)
                 .HasForeignKey(t => t.SubtitleId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.ToTable(nameof(EpisodeSubtitle));
        }
    }
}
