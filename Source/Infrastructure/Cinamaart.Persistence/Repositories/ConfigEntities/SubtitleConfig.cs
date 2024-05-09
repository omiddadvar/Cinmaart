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
            throw new NotImplementedException();
        }
    }
}
