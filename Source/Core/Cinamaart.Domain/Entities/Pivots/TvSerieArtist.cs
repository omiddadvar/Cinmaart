using Cinamaart.Domain.Abstractions;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class TvSerieArtist 
    {
        public long Id { get; set; }
        public int TvSerieId { get; set; }
        public TvSerie TvSerie { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
