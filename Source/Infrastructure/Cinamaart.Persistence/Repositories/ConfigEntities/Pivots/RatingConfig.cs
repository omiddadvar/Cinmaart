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
    internal class RatingConfig : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasOne(t => t.User)
                 .WithMany(e => e.Ratings)
                 .HasForeignKey(t => t.UserId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.HasOne(t => t.Subtitle)
                 .WithMany(e => e.Ratings)
                 .HasForeignKey(t => t.SubtitleId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.ToTable(nameof(Rating));
        }
    }
}
