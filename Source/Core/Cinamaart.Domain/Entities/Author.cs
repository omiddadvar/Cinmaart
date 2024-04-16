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
    [Table("Authors")]
    public class Author : BaseEntity<int>
    {
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(4000)]
        public string? Description { get; set; }

        public ICollection<Subtitle>? Subtitles {  get; set; }
    }
}
