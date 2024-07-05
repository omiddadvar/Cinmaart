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
    public class EpisodeSubtitle : IAuditablaEntity<long>
    {
        public long Id { get; set; }
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
