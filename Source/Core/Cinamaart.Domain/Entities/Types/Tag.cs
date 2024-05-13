using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Pivots;
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
    [Table("Tags")]
    public class Tag : BaseTypeEntity
    {
        public ICollection<MovieTag> MovieTags { get; set; } = new List<MovieTag>();
        public ICollection<TvSerieTag> TvSerieTags { get; set; } = new List<TvSerieTag>();

    }
}
