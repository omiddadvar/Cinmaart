using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class SubtitleDocument : IAuditablaEntity<long>
    {
        public long Id { get; set; }
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
        public long DocumentId { get; set; }
        public Document Document { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
