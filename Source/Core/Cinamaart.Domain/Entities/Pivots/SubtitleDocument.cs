using Cinamaart.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    [Table("SubtitleDocuments")]
    public class SubtitleDocument : BaseAuditableEntity<long>
    {
        [ForeignKey("Subtitle")]
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
        [ForeignKey("Document")]
        public long DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
