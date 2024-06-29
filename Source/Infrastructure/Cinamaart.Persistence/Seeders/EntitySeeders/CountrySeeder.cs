using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities;
using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    public class CountrySeeder(MainDBContext dbContext) : 
        BaseEnumSeeder<CountryEnum , Country>(dbContext)
    {
        public override uint Order => 1;

    }
}
