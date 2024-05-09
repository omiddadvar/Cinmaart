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
    internal class SubtitleDocumentConfig : IEntityTypeConfiguration<SubtitleDocument>
    {
        public void Configure(EntityTypeBuilder<SubtitleDocument> builder)
        {
            throw new NotImplementedException();
        }
    }
}
