using Cinamaart.Domain.Entities.Pivots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Pivots
{
    internal class UserDocumentConfig : IEntityTypeConfiguration<UserDocument>
    {
        public void Configure(EntityTypeBuilder<UserDocument> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.User)
                .WithMany(e => e.UserDocuments)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(t => t.Document)
                 .WithMany(e => e.UserDocuments)
                 .HasForeignKey(t => t.DocumentId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.HasOne(t => t.UserDocumentType)
                 .WithMany(e => e.UserDocuments)
                 .HasForeignKey(t => t.UserDocumentTypeId)
                 .OnDelete(DeleteBehavior.SetNull)
                 .IsRequired();

            builder.ToTable(nameof(UserDocument));
        }
    }
}
