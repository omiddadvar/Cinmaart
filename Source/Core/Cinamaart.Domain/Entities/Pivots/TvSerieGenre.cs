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
    [Table("TvSerieGenres")]
    public class TvSerieGenre : BaseEntity<long>
    {
        [ForeignKey("TVSerie")]
        public int TvSerieId { get; set; }
        public TvSerie TVSerie { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
