using Cinamaart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities
{
    internal class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(1000);

            builder.HasOne(t => t.Country)
                .WithMany(e => e.Movies)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(nameof(Movie));
        }
    }
}
