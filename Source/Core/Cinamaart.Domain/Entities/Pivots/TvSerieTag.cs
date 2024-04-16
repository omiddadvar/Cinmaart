using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    [Table("TvSerieTags")]
    public class TvSerieTag : BaseAuditableEntity<long>
    {
        [ForeignKey("TVSerie")]
        public int TvSerieId { get; set; }
        public TvSerie TVSerie { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
