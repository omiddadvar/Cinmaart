using Cinamaart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities
{
    internal class TvSerieConfig : IEntityTypeConfiguration<TvSerie>
    {
        public void Configure(EntityTypeBuilder<TvSerie> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(10000);

            builder.HasOne(t => t.Country)
                .WithMany(e => e.TvSeries)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(nameof(TvSerie));
        }
    }
}
