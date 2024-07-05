using Cinamaart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
