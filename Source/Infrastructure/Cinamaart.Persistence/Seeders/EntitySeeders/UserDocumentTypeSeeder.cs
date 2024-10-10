using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Contexts;


namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    internal class UserDocumentTypeSeeder(MainDBContext dBContext) :
        BaseEnumSeeder<UserDocumentTypeEnum, UserDocumentType>(dBContext)
    {
        public override uint Order => 6;

        protected override IList<UserDocumentType> getPreparedData(List<EnumDataModel> enumData)
        {
            var data = new List<UserDocumentType>();
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
