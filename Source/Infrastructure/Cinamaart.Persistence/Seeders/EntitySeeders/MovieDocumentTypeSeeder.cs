using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    internal class MovieDocumentTypeSeeder(MainDBContext dBContext) : 
        BaseEnumSeeder<MovieDocumentTypeEnum , MovieDocumentType>(dBContext)
    {
        public override uint Order => 7;

        protected override IList<MovieDocumentType> getPreparedData(List<EnumDataModel> enumData)
        {
            var data = new List<MovieDocumentType>();
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
