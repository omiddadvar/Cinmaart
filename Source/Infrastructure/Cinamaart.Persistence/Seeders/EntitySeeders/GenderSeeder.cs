using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    public class GenderSeeder(MainDBContext dbContext) :
        BaseEnumSeeder<GenderEnum, Gender>(dbContext)
    {
        public override uint Order => 2;
    }
}
