using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class Rating : IAuditablaEntity<long>
    {
        public long Id { get; set; }
        public int Rate { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
