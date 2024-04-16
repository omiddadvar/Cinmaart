using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    [Table("UserDocuments")]
    public class UserDocument : BaseAuditableEntity<long>
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Document")]
        public long DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
