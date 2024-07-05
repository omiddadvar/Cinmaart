using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Pivots;
using Cinamaart.Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities
{
    public class Document : IAuditablaEntity<long>
    {
        public long Id { get; set; }
        public string Name {  get; set; }
        public string Extention { get; set; }
        public string SavedName { get; set; }
        public int DocumentTypeId {  get; set; }
        public DocumentType DocumentType {  get; set; }

        public ICollection<SubtitleDocument> SubtitleDocuments { get; set; } = new List<SubtitleDocument>();
        public ICollection<UserDocument> UserDocuments { get; set; } = new List<UserDocument>();
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
