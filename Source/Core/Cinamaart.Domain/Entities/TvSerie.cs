using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Pivots;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities
{
    public class TvSerie :  BaseAuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Season> Seasons { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public ICollection<TvSerieArtist> TvSerieArtists { get; set; } = new List<TvSerieArtist>();
        public ICollection<TvSerieGenre> TvSerieGenres { get; set; } = new List<TvSerieGenre>();
        public ICollection<TvSerieTag> TvSerieTags { get; set; } = new List<TvSerieTag>();

    }
}
