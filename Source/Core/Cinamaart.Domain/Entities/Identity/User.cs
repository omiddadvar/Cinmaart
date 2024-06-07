using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Pivots;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Identity
{
    public class User : IdentityUser<long>, IBaseEntity<long>
    {
        public Author? Author { get; set; }
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<UserDocument> UserDocuments { get; set; } = new List<UserDocument>();

    }
}
