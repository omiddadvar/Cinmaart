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
    [Table("Genders")]
    public class Gender : BaseTypeEntity
    {
        public ICollection<Artist> Artists { get; } = new List<Artist>();

    }
}
