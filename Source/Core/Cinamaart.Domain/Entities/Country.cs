using Cinamaart.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities
{
    [Table("Countries")]
    public class Country : BaseEntity<int>
    {
        [StringLength(100) , Unicode(false)]
        public string Name {  get; set; }
    }
}
