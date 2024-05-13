using Cinamaart.Domain.Common;
using Cinamaart.Domain.Entities.Pivots;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Types
{
    [Table("Genres")]
    public class Genre : BaseTypeEntity
    {
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<TvSerieGenre> TvSerieGenres { get; set; } = new List<TvSerieGenre>();


    }
}
