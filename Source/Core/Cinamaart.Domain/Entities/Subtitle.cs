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
    [Table("Subtitles")]
    public class Subtitle : BaseAuditableEntity<long>
    {
        [StringLength(1000)]
        public string Name {  get; set; }

        [StringLength(4000)]
        public string Description { get; set; }
        [StringLength(200)]
        public string? AuthorName { get; set; }
        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }

    }
}
