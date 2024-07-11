namespace Cinamaart.Domain.Abstractions
{
    public class Result<T>
        where T : class
    {
        public Result(bool isSuccess, T? data, Error error)
        {
            if (isSuccess && error != Error.None ||
               !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }
            IsSuccess = isSuccess;
            Error = error;
            Data = data;
        }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        public T? Data { get; }

        public static Result<T> Success(T data)
            => new Result<T>(true, data, Error.None);
        public static Result<T> Failure(Error error)
            => new Result<T>(false, null, error);
        public static Result<T> Failure(string code, string? description = null)
            => new Result<T>(false, null, new Error(code, description));
    }
}
