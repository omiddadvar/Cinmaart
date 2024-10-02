using Cinamaart.Domain.Entities.Pivots;
using Cinamaart.Domain.Entities.Types;

namespace Cinamaart.Domain.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public ICollection<MovieArtist> MovieArtists { get; set; } = new List<MovieArtist>();
        public ICollection<TvSerieArtist> TvSerieArtists { get; set; } = new List<TvSerieArtist>();
    }
}
