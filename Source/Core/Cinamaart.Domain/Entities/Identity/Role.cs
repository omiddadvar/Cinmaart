using Cinamaart.Domain.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Identity
{
    public class Role : IdentityRole<int> , IBaseEntity<int>
    {

    }
}
