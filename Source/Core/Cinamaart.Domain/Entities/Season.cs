using Cinamaart.Domain.Abstractions;

namespace Cinamaart.Domain.Entities
{
    public class Season : IAuditablaEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int TvSerieId { get; set; }
        public TvSerie TvSerie { get; set; }

        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
