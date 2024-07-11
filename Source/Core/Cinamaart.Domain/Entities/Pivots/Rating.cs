using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class Rating : IAuditablaEntity
    {
        public long Id { get; set; }
        public int Rate { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long SubtitleId { get; set; }
        public Subtitle Subtitle { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
