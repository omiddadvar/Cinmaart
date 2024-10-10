using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    internal class SubtitleDocumentTypeSeeder(MainDBContext dBContext) : 
        BaseEnumSeeder<SubtitleDocumentTypeEnum , SubtitleDocumentType>(dBContext)
    {
        public override uint Order => 9;

        protected override IList<SubtitleDocumentType> getPreparedData(List<EnumDataModel> enumData)
        {
            var data = new List<SubtitleDocumentType>();
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
