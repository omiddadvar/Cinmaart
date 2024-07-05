using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Abstractions
{
    internal interface IAuditablaEntity<TPrimaryKey> : IBaseEntity<TPrimaryKey>
    {
        public DateTime CraetedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }
}
