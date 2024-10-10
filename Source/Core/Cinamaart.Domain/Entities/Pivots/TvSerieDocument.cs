using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class TvSerieDocument : IAuditablaEntity
    {
        public long Id { get; set; }
        public int TvSerieId { get; set; }
        public TvSerie TvSerie { get; set; }
        public long DocumentId { get; set; }
        public Document Document { get; set; }
        public int TvSeriesDocumentTypeId { get; set; }
        public TvSeriesDocumentType TvSeriesDocumentType { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
