using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class TvSerieArtist : IBaseEntity<long>
    {
        public long Id { get; set; }
        public int TvSerieId { get; set; }
        public TvSerie TvSerie { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
