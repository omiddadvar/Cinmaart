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
    internal class SeasonConfig : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(1000);

            builder.HasOne(t => t.TvSerie)
                .WithMany(e => e.Seasons)
                .HasForeignKey(t => t.TvSerieId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable(nameof(Season));
        }
    }
}
