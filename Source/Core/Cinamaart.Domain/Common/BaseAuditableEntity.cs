using Cinamaart.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Common
{
    [NotMapped]
    public class BaseAuditableEntity<TPrimaryKey> : BaseEntity<TPrimaryKey>, IAuditablaEntity<TPrimaryKey>
    {
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
