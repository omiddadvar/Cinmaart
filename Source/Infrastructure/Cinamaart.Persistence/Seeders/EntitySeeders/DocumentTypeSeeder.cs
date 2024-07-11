using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    internal class DocumentTypeSeeder(MainDBContext dbContext) :
        BaseEnumSeeder<DocumentTypeEnum, DocumentType>(dbContext)
    {
        public override uint Order => 3;
        protected override IList<DocumentType> getPreparedData(List<EnumDataModel> enumData)
        {
            var data = new List<DocumentType>();
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
