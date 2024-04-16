using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Types;
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
    [Table("Documents")]
    public class Document : BaseAuditableEntity<long>
    {
        [StringLength(500)]
        public string Name {  get; set; }
        [StringLength(100) , Unicode(false)]
        public string Extention { get; set; }
        [StringLength(1000), Unicode(false)]
        public string SavedName { get; set; }
        [ForeignKey("DocumentType")]
        public int DocumentTypeId {  get; set; }
        public DocumentType DocumentType {  get; set; }
    }
}
