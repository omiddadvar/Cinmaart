using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    internal class DocumentTypeSeeder(MainDBContext dbContext) :
        BaseEnumSeeder<DocumentTypeEnum, DocumentType>(dbContext)
    {
        public override uint Order => 3;
    }
}
