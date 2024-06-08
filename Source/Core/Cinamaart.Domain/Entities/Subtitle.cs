using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Pivots;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities
{
    public class Subtitle : BaseAuditableEntity<long>
    {
        public string Name {  get; set; }

        public string Description { get; set; }
        public string? AuthorName { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }

        public ICollection<EpisodeSubtitle> EpisodeSubtitles { get; set; } = new List<EpisodeSubtitle>();
        public ICollection<MovieSubtitle> MovieSubtitles { get; set; } = new List<MovieSubtitle>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<SubtitleDocument> SubtitleDocuments { get; set; } = new List<SubtitleDocument>();

    }
}
