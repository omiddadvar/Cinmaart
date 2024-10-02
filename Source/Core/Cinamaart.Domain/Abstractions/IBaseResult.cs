namespace Cinamaart.Domain.Abstractions
{
    public interface IBaseResult
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        IList<Error>? Errors { get; }
    }
}
