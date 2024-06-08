using Cinamaart.Domain.Common;
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
    public class Country : BaseEntity<int>
    {
        public string Name {  get; set; }

        public ICollection<Artist> Artists { get; } = new List<Artist>();
        public ICollection<Movie> Movies { get; } = new List<Movie>();
        public ICollection<TvSerie> TvSeries { get; } = new List<TvSerie>();

    }
}
