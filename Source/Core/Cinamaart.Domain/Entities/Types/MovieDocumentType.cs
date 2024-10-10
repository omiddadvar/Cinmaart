using Cinamaart.Domain.Entities.Pivots;

namespace Cinamaart.Domain.Entities.Types
{
    public class MovieDocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieDocument> MovieDocuments { get; set; } = new List<MovieDocument>();

    }
}
