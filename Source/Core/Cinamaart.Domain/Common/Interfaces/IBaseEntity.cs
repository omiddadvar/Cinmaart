using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Common.Interfaces
{
    public interface IBaseEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
