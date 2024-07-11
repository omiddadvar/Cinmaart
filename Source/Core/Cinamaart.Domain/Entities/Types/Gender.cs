using Cinamaart.Domain.Abstractions;

namespace Cinamaart.Domain.Entities.Types
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; } = new List<Artist>();

    }
}
