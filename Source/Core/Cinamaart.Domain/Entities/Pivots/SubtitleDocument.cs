using Cinamaart.Domain.Abstractions;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class SubtitleDocument : IAuditablaEntity<long>
    {
        public long Id { get; set; }
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
        public long DocumentId { get; set; }
        public Document Document { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
