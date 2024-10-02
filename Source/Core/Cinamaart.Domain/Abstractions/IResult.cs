namespace Cinamaart.Domain.Abstractions
{
    public interface IResult<T> : IBaseResult
    {
        T? Data { get; }
    }
}
