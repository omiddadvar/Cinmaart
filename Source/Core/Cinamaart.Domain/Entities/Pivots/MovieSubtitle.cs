using Cinamaart.Domain.Abstractions;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class MovieSubtitle : IAuditablaEntity<long>
    {
        public long Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
