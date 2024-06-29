using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    public class GenderSeeder(MainDBContext dbContext) :
        BaseEnumSeeder<GenderEnum , Gender>(dbContext)
    {
        public override uint Order => 2;
    }
}
