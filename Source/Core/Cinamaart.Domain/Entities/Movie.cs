using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Pivots;
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
    public class Movie : BaseAuditableEntity<int>
    {
        public string Name {  get; set; }
        public int Year {  get; set; }
        public string Description { get; set; }
        public int? CountryId {  get; set; }
        public Country? Country {  get; set; }


        public ICollection<MovieArtist> MovieArtists { get; set; } = new List<MovieArtist>();
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<MovieSubtitle> MovieSubtitles { get; set; } = new List<MovieSubtitle>();
        public ICollection<MovieTag> MovieTags { get; set; } = new List<MovieTag>();
    }
}
