using Cinamaart.Domain.Entities.Pivots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Pivots
{
    internal class TvSerieTagConfig : IEntityTypeConfiguration<TvSerieTag>
    {
        public void Configure(EntityTypeBuilder<TvSerieTag> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.TvSerie)
               .WithMany(e => e.TvSerieTags)
               .HasForeignKey(t => t.TvSerieId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

            builder.HasOne(t => t.Tag)
                 .WithMany(e => e.TvSerieTags)
                 .HasForeignKey(t => t.TagId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.ToTable(nameof(TvSerieTag));
        }
    }
}
