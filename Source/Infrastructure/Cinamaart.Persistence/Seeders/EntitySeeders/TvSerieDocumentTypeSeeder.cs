using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Abstractions;
using Cinamaart.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Seeders.EntitySeeders
{
    internal class TvSerieDocumentTypeSeeder(MainDBContext dBContext) :
        BaseEnumSeeder<TvSeriesDocumentTypeEnum, TvSeriesDocumentType>(dBContext)
    {
        public override uint Order => 8;

        protected override IList<TvSeriesDocumentType> getPreparedData(List<EnumDataModel> enumData)
        {
            var data = new List<TvSeriesDocumentType>();
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
