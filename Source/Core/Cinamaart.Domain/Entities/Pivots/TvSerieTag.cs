using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Types;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class TvSerieTag 
    {
        public long Id { get; set; }
        public int TvSerieId { get; set; }
        public TvSerie TvSerie { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
