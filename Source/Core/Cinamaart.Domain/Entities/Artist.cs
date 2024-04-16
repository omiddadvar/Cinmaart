using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities
{
    public class Artist : BaseEntity<int>
    {
        [StringLength(200)]
        public string FullName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? BirthDate { get; set; }
        [ForeignKey("Gender")]
        public Int16 GenderId { get; set; }
        public Gender Gender { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
