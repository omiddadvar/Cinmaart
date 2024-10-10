﻿using Cinamaart.Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories.ConfigEntities.Types
{
    internal class TvSeriesDocumentTypeConfig : IEntityTypeConfiguration<TvSeriesDocumentType>
    {
        public void Configure(EntityTypeBuilder<TvSeriesDocumentType> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(maxLength: 100);
            builder.ToTable(nameof(TvSeriesDocumentType));
        }
    }
}
