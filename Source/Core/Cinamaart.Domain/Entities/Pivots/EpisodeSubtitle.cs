using Cinamaart.Domain.Abstractions;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class EpisodeSubtitle : IAuditablaEntity
    {
        public long Id { get; set; }
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
