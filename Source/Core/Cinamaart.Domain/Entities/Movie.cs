using Cinamaart.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities
{
    [Table("Movies")]
    public class Movie : BaseAuditableEntity<int>
    {
        [StringLength(1000)]
        public string Name {  get; set; }
        public int Year {  get; set; }
        public string Description { get; set; }
        [ForeignKey("Country")]
        public int CountryId {  get; set; }
        public Country Country {  get; set; }
    }
}
