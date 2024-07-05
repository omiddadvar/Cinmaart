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
    internal class TvSerieGenreConfig : IEntityTypeConfiguration<TvSerieGenre>
    {
        public void Configure(EntityTypeBuilder<TvSerieGenre> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.TvSerie)
                .WithMany(e => e.TvSerieGenres)
                .HasForeignKey(t => t.TvSerieId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(t => t.Genre)
                 .WithMany(e => e.TvSerieGenres)
                 .HasForeignKey(t => t.GenreId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.ToTable(nameof(TvSerieGenre));
        }
    }
}
