using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Pivots;

namespace Cinamaart.Domain.Entities
{
    public class Subtitle : IAuditablaEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? AuthorName { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }

        public ICollection<EpisodeSubtitle> EpisodeSubtitles { get; set; } = new List<EpisodeSubtitle>();
        public ICollection<MovieSubtitle> MovieSubtitles { get; set; } = new List<MovieSubtitle>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<SubtitleDocument> SubtitleDocuments { get; set; } = new List<SubtitleDocument>();
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
