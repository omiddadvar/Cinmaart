using Cinamaart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities
{
    internal class EpisodeConfig : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(1000);

            builder.HasOne(t => t.Season)
                .WithMany(e => e.Episodes)
                .HasForeignKey(t => t.SeasonId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable(nameof(Episode));
        }
    }
}
