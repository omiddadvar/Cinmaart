using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories.ConfigEntities
{
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(t => t.Name).HasMaxLength(maxLength: 100);
            builder.Property(t => t.Description).HasMaxLength(maxLength: 4000);

            builder.HasOne(t => t.User)
                .WithOne(e => e.Author)
                .HasForeignKey<Author>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable("Authors");
        }
    }
}
