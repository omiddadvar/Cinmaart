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
    internal class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(t => t.Name).HasMaxLength(1000);

            builder.HasOne(t => t.Country)
                .WithMany(e => e.Movies)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(nameof(Movie));
        }
    }
}
