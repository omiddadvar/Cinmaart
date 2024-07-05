using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    internal class DocumentTypeSeeder(MainDBContext dbContext) :
        BaseEnumSeeder<DocumentTypeEnum, DocumentType>(dbContext)
    {
        public override uint Order => 3;
    }
}
