using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Pivots;

namespace Cinamaart.Domain.Entities
{
    public class Episode : IAuditablaEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public ICollection<EpisodeSubtitle> EpisodeSubtitles { get; set; } = new List<EpisodeSubtitle>();
    }
}
