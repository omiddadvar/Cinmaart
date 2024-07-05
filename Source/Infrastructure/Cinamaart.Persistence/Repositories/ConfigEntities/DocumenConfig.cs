using Cinamaart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities
{
    internal class DocumenConfig : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(500);
            builder.Property(t => t.Extention).IsUnicode(false).HasMaxLength(100);
            builder.Property(t => t.SavedName).IsUnicode(false).HasMaxLength(1000);

            builder.HasOne(t => t.DocumentType)
                .WithMany(e => e.Documents)
                .HasForeignKey(t => t.DocumentTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable(nameof(Document));
        }
    }
}
