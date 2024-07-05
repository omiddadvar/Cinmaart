using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    public class CountrySeeder(MainDBContext dbContext) :
        BaseEnumSeeder<CountryEnum, Country>(dbContext)
    {
        public override uint Order => 1;

    }
}
