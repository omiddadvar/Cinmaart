using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Common
{
    [NotMapped]
    public class BaseTypeEntity : BaseEntity<int>
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
