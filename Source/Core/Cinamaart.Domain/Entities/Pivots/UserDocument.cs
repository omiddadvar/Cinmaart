using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class UserDocument : IAuditablaEntity<long>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long DocumentId { get; set; }
        public Document Document { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
