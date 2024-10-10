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
    internal class MovieDocumentConfig : IEntityTypeConfiguration<MovieDocument>
    {
        public void Configure(EntityTypeBuilder<MovieDocument> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Movie)
                .WithMany(e => e.MovieDocuments)
                .HasForeignKey(t => t.MovieId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(t => t.Document)
                 .WithMany(e => e.MovieDocuments)
                 .HasForeignKey(t => t.DocumentId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.ToTable(nameof(MovieDocument));
        }
    }
}
