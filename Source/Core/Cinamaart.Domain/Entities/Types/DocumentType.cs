using Cinamaart.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Types
{
    public class DocumentType : BaseTypeEntity
    {
        public ICollection<Document> Documents { get; set;} = new List<Document>(); 
    }
}
