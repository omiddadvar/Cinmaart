using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Abstractions
{
    public interface IBaseTypeEntity : IBaseEntity<int>
    {
        string Name { get; set; }
    }
}
