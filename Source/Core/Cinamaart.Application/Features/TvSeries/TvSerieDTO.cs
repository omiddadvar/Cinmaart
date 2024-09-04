using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.TvSeries
{
    public class TvSerieDTO
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public string Description {  get; set; }
        public int? CountryId {  get; set; }
        public string? Country {  get; set; }
    }
}
