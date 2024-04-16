using Cinamaart.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    [Table("EpisodeSubtitles")]
    public class EpisodeSubtitle : BaseAuditableEntity<long>
    {
        [ForeignKey("Episode")]
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
        [ForeignKey("Subtitle")]
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
    }
}
