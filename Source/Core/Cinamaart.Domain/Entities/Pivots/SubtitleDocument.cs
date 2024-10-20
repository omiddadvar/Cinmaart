using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Types;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class SubtitleDocument : IAuditablaEntity
    {
        public long Id { get; set; }
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
        public long DocumentId { get; set; }
        public Document Document { get; set; }
        public int? SubtitleDocumentTypeId { get; set; }
        public SubtitleDocumentType? SubtitleDocumentType { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
