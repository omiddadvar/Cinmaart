﻿using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Pivots
{
    [Table("TvSerieTags")]
    public class TvSerieTag : BaseEntity<long>
    {
        [ForeignKey("TVSerie")]
        public int TvSerieId { get; set; }
        public TvSerie TvSerie { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
