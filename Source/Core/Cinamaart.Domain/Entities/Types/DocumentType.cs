using Cinamaart.Domain.Abstractions;

namespace Cinamaart.Domain.Entities.Types
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
