using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Abstractions
{
    public interface IResult<T> : IBaseResult
    {
        T? Data { get; }
    }
}
