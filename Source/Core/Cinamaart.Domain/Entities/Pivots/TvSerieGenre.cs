using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Types;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class TvSerieGenre
    {
        public long Id { get; set; }
        public int TvSerieId { get; set; }
        public TvSerie TvSerie { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
