using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class MovieDocument : IAuditablaEntity
    {
        public long Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public long DocumentId { get; set; }
        public Document Document { get; set; }
        public int MovieDocumentTypeId { get; set; }
        public MovieDocumentType MovieDocumentType { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
