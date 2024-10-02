using Cinamaart.Domain.Abstractions;

namespace Cinamaart.Application.Abstractions
{
    public interface IWebServiceResult<T> : IResult<T>
    {
        int StatusCode { get; }
    }
}
