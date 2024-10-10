using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Entities.Types;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class UserDocument : IAuditablaEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long DocumentId { get; set; }
        public Document Document { get; set; }
        public int UserDocumentTypeId { get; set; }
        public UserDocumentType UserDocumentType { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
