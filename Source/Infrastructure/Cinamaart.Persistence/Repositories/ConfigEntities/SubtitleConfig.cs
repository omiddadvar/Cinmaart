using Cinamaart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities
{
    internal class SubtitleConfig : IEntityTypeConfiguration<Subtitle>
    {
        public void Configure(EntityTypeBuilder<Subtitle> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(1000);
            builder.Property(t => t.Description).HasMaxLength(4000);
            builder.Property(t => t.AuthorName).HasMaxLength(200);

            builder.HasOne(t => t.Author)
                .WithMany(e => e.Subtitles)
                .HasForeignKey(t => t.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(nameof(Subtitle));
        }
    }
}
