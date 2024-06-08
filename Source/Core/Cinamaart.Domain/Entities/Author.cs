using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities
{
    public class Author : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<Subtitle>? Subtitles {  get; set; }

    }
}
