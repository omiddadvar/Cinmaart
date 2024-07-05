using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Pivots;

namespace Cinamaart.Domain.Entities
{
    public class TvSerie : IAuditablaEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Season> Seasons { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public ICollection<TvSerieArtist> TvSerieArtists { get; set; } = new List<TvSerieArtist>();
        public ICollection<TvSerieGenre> TvSerieGenres { get; set; } = new List<TvSerieGenre>();
        public ICollection<TvSerieTag> TvSerieTags { get; set; } = new List<TvSerieTag>();
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
