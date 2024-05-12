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
    internal class SubtitleConfig : IEntityTypeConfiguration<Subtitle>
    {
        public void Configure(EntityTypeBuilder<Subtitle> builder)
        {
            builder.Property(t => t.Name).HasMaxLength(1000);
            builder.Property(t => t.Description).HasMaxLength(4000);
            builder.Property(t => t.AuthorName).HasMaxLength(200);

            builder.HasOne(t => t.Author)
                .WithMany(e => e.Subtitles)
                .HasForeignKey(t => t.AuthorId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable("Subtitles");
        }
    }
}
