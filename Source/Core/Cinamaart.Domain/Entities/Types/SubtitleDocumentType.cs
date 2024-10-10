using Cinamaart.Domain.Entities.Pivots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Types
{
    public class SubtitleDocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubtitleDocument> SubtitleDocuments { get; set; } = new List<SubtitleDocument>();

    }
}
