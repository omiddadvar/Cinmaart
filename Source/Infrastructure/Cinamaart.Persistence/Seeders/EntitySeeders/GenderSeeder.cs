using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    public class GenderSeeder(MainDBContext dbContext) :
        BaseEnumSeeder<GenderEnum, Gender>(dbContext)
    {
        public override uint Order => 2;
        protected override IList<Gender> getPreparedData(List<EnumDataModel> enumData)
        {
            var data = new List<Gender>();
            enumData.ForEach(item =>
            {
                data.Add(new()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            });
            return data;
        }
    }
}
