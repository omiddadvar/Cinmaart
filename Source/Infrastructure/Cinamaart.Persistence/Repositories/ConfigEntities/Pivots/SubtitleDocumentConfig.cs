using Cinamaart.Domain.Entities.Pivots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Pivots
{
    internal class SubtitleDocumentConfig : IEntityTypeConfiguration<SubtitleDocument>
    {
        public void Configure(EntityTypeBuilder<SubtitleDocument> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Subtitle)
               .WithMany(e => e.SubtitleDocuments)
               .HasForeignKey(t => t.SubtitleId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

            builder.HasOne(t => t.Document)
                 .WithMany(e => e.SubtitleDocuments)
                 .HasForeignKey(t => t.DocumentId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.HasOne(t => t.SubtitleDocumentType)
                 .WithMany(e => e.SubtitleDocuments)
                 .HasForeignKey(t => t.SubtitleDocumentTypeId)
                 .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(nameof(SubtitleDocument));
        }
    }
}
