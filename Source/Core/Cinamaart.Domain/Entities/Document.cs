using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Pivots;
using Cinamaart.Domain.Entities.Types;

namespace Cinamaart.Domain.Entities
{
    public class Document : IAuditablaEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public string SavedName { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }

        public ICollection<SubtitleDocument> SubtitleDocuments { get; set; } = new List<SubtitleDocument>();
        public ICollection<UserDocument> UserDocuments { get; set; } = new List<UserDocument>();
        public ICollection<MovieDocument> MovieDocuments { get; set; } = new List<MovieDocument>();
        public ICollection<TvSerieDocument> TvSerieDocuments { get; set; } = new List<TvSerieDocument>();
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
