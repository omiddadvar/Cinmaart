using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Movies
{
    internal class MovieDTO
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }

    }
}
