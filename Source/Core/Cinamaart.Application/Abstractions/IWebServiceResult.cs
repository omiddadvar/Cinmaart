using Cinamaart.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Abstractions
{
    public interface IWebServiceResult<T> : IResult<T>
    {
        int StatusCode { get; }
    }
}
