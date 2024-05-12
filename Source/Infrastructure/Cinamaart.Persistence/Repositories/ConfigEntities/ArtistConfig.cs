using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories.ConfigEntities
{
    internal class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.FullName).HasMaxLength(maxLength: 200);
            builder.Property(t => t.BirthDate).HasColumnType("Date");
            
            builder.HasOne(t => t.Gender)
                .WithMany(e => e.Artists)
                .HasForeignKey(t => t.GenderId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(t => t.Country)
                .WithMany(e => e.Artists)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable(nameof(Artist));
        }
    }
}
