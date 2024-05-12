using Cinamaart.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities
{
    [Table("Seasons")]
    public class Season : BaseAuditableEntity<int>
    {
        [StringLength(1000)]
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        [ForeignKey("TvSerie")]
        public int TvSerieId {  get; set; }
        public TvSerie TvSerie {  get; set; }

        public ICollection<Episode> Episodes {  get; set; } = new List<Episode>();
    }
}
