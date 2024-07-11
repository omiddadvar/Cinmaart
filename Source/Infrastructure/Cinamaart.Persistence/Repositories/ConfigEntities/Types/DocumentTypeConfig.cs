using Cinamaart.Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Types
{
    internal class DocumentTypeConfig : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedNever();
            builder.Property(t => t.Name).HasMaxLength(maxLength: 100);
            builder.ToTable(nameof(DocumentType));
        }
    }
}
