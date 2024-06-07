using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Abstractions
{
    public class Result
    {
        public Result(bool isSuccess , Error error)
        {
            if (isSuccess && error != Error.None ||
               !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }
            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; }
        public Error Error { get; }

        public static Result Success() => new Result(true, Error.None);
        public static Result Failure(Error error) => new Result(false, error);
    }
}
