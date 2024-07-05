using Cinamaart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities
{
    internal class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.FullName).HasMaxLength(maxLength: 200);
            builder.Property(t => t.BirthDate).HasColumnType("Date");

            builder.HasOne(t => t.Gender)
                .WithMany(e => e.Artists)
                .HasForeignKey(t => t.GenderId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(t => t.Country)
                .WithMany(e => e.Artists)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(nameof(Artist));
        }
    }
}
