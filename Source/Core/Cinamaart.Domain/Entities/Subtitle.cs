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
    [Table("Subtitles")]
    public class Subtitle : BaseAuditableEntity<long>
    {
        [StringLength(1000)]
        public string Name {  get; set; }

        [StringLength(4000)]
        public string Description { get; set; }
        [StringLength(200)]
        public string? AuthorName { get; set; }
        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }

        public ICollection<EpisodeSubtitle> EpisodeSubtitles { get; set; } = new List<EpisodeSubtitle>();
        public ICollection<MovieSubtitle> MovieSubtitles { get; set; } = new List<MovieSubtitle>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<SubtitleDocument> SubtitleDocuments { get; set; } = new List<SubtitleDocument>();

    }
}
