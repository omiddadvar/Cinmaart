using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class TvSerieTag : IBaseEntity<long>
    {
        public long Id { get; set; }
        public int TvSerieId { get; set; }
        public TvSerie TvSerie { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
