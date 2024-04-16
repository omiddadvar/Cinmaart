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
    internal class Rating : BaseAuditableEntity<long>
    {
        [Range(1,5)]
        public int Rate { get; set; }
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Subtitle")]
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
    }
}
