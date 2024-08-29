using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Abstractions
{
    public interface IBaseResult
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        IList<Error>? Errors { get; }
    }
}
