using Cinamaart.Domain.Entities.Types;
using Cinamaart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Features.Artists.Queries.GetAllArtists
{
    public class GetAllArtistsDTO
    {
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
    }
}
