using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Common
{
    public class BaseTypeEntity : BaseEntity<Int16>
    {
        [StringLength(100) , Unicode(false)]
        public string Name { get; set; }
    }
}
