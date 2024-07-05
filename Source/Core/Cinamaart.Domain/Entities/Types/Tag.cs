using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Pivots;

namespace Cinamaart.Domain.Entities.Types
{
    public class Tag : IBaseTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieTag> MovieTags { get; set; } = new List<MovieTag>();
        public ICollection<TvSerieTag> TvSerieTags { get; set; } = new List<TvSerieTag>();

    }
}
