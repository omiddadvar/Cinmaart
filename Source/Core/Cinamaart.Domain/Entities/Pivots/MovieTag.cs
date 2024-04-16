using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    [Table("MovieTags")]
    public class MovieTag : BaseAuditableEntity<long>
    {
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
