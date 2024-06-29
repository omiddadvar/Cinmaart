using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Abstractions
{
    public class Result
    {
        public Result(bool isSuccess , object? data, Error error)
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
        public object? Data { get; }

        public static Result Success(object data) 
            => new Result(true , data, Error.None);
        public static Result Failure(Error error) 
            => new Result(false,null, error);
        public static Result Failure(string code, string? description = null)
            => new Result(false,null, new Error(code, description));
    }
}
