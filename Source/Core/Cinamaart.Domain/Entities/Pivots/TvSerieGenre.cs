using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class TvSerieGenre : BaseEntity<long>
    {
        public int TvSerieId { get; set; }
        public TvSerie TvSerie { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
