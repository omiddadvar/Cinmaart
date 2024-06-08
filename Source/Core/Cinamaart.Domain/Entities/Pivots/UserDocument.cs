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
    public class UserDocument : BaseAuditableEntity<long>
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
