using Cinamaart.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Types
{
    public class ArtistRole : BaseEntity<int>
    {
        [StringLength(100) , DataType("VARCHAR")]
        public string Name {  get; set; }
    }
}
