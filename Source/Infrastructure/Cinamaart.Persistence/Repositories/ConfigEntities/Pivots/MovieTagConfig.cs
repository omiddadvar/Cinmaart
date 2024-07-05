using Cinamaart.Domain.Entities.Pivots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Pivots
{
    internal class MovieTagConfig : IEntityTypeConfiguration<MovieTag>
    {
        public void Configure(EntityTypeBuilder<MovieTag> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Movie)
                 .WithMany(e => e.MovieTags)
                 .HasForeignKey(t => t.MovieId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.HasOne(t => t.Tag)
                 .WithMany(e => e.MovieTags)
                 .HasForeignKey(t => t.TagId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .IsRequired();

            builder.ToTable(nameof(MovieTag));
        }
    }
}
