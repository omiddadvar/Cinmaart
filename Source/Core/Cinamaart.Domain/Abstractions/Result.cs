namespace Cinamaart.Domain.Abstractions
{
    public class Result<T> : IResult<T>
    {
        public Result(bool isSuccess, T? data, Error error)
        {
            if (isSuccess && error != Error.None ||
               !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }
            IsSuccess = isSuccess;
            if (error != Error.None)
                Errors = new[] { error };
            Data = data;
        }
        public Result(bool isSuccess, T? data, IList<Error>? errors)
        {
            if (errors is not null)
            {
                Error? invalidError = errors
                    .Where(e => (isSuccess && e != Error.None || !isSuccess && e == Error.None))
                    .Select(e => e)
                    .FirstOrDefault();
                if (invalidError is not null)
                {
                    throw new ArgumentException("Invalid error", nameof(invalidError));
                }
            }
            IsSuccess = isSuccess;
            Errors = errors;
            Data = data;
        }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public IList<Error>? Errors { get; }
        public T? Data { get; }

        public static Result<T> Success(T data)
            => new Result<T>(true, data, Error.None);
        public static Result<T> Failure(Error error)
            => new Result<T>(false, default(T), error);
        public static Result<T> Failure(string code, string? description = null)
            => new Result<T>(false, default(T), new Error(code, description));
        public static Result<T> Failure(IList<Error>? errors)
            => new Result<T>(false, default(T), errors);
    }
}
