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
    internal class MovieSubtitleConfig : IEntityTypeConfiguration<MovieSubtitle>
    {
        public void Configure(EntityTypeBuilder<MovieSubtitle> builder)
        {
            builder.HasOne(t => t.Movie)
                 .WithMany(e => e.MovieSubtitles)
                 .HasForeignKey(t => t.MovieId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.HasOne(t => t.Subtitle)
                 .WithMany(e => e.MovieSubtitles)
                 .HasForeignKey(t => t.SubtitleId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.ToTable(nameof(MovieSubtitle));
        }
    }
}
