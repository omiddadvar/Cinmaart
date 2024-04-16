using Cinamaart.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    [Table("MovieSubtitles")]
    public class MovieSubtitle : BaseAuditableEntity<long>
    {
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [ForeignKey("Subtitle")]
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
    }
}
