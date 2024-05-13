using Cinamaart.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    [Table("TvSerieArtists")]
    public class TvSerieArtist : BaseEntity<long>
    {
        [ForeignKey("TVSerie")]
        public int TvSerieId { get; set; }
        public TvSerie TvSerie { get; set; }
        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
