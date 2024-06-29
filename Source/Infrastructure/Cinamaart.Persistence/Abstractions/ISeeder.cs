using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Abstractions
{
    public interface ISeeder
    {
        uint Order { get; }
        void Seed();
    }
}
