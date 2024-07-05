using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Types;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class MovieTag : IBaseEntity<long>
    {
        public long Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
