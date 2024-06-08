using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Pivots;
using Cinamaart.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities
{
    public class Artist : BaseEntity<int>
    {
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Int16 GenderId { get; set; }
        public Gender Gender { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<MovieArtist> MovieArtists { get; set; } = new List<MovieArtist>();
        public ICollection<TvSerieArtist> TvSerieArtists { get; set; } = new List<TvSerieArtist>();
    }
}
