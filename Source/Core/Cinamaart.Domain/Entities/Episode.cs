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
    public class Episode : BaseAuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public ICollection<EpisodeSubtitle> EpisodeSubtitles {  get; set; } = new List<EpisodeSubtitle>();
    }
}
