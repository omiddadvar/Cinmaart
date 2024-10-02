using Cinamaart.Domain.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Cinamaart.Application.Abstractions
{
    public class WebServiceResult<T> : Result<T>, IWebServiceResult<T>
    {
        public WebServiceResult(int statusCode, bool isSuccess, T? data, Error error)
            : base(isSuccess, data, error)
        {
            StatusCode = statusCode;
        }
        public WebServiceResult(int statusCode, bool isSuccess, T? data, IList<Error>? errors)
                : base(isSuccess, data, errors)
        {
            StatusCode = statusCode;
        }
        public int StatusCode { get; }


        public static WebServiceResult<T> Success(T data)
             => new WebServiceResult<T>(StatusCodes.Status200OK, true, data, Error.None);
        public static WebServiceResult<T> Forbidden(string code, string? description = null)
            => new WebServiceResult<T>(StatusCodes.Status403Forbidden, false, default(T), new Error(code, description));
        public static WebServiceResult<T> UnAuthorized(string code, string? description = null)
            => new WebServiceResult<T>(StatusCodes.Status401Unauthorized, false, default(T), new Error(code, description));
        public static WebServiceResult<T> NotFound(string code, string? description = null)
            => new WebServiceResult<T>(StatusCodes.Status404NotFound, false, default(T), new Error(code, description));
        public static WebServiceResult<T> Failure(Error error)
            => new WebServiceResult<T>(StatusCodes.Status400BadRequest, false, default(T), error);
        public static WebServiceResult<T> Failure(int statusCode, Error error)
            => new WebServiceResult<T>(statusCode, false, default(T), error);
        public static WebServiceResult<T> Failure(int statusCode, string code, string? description = null)
            => new WebServiceResult<T>(statusCode, false, default(T), new Error(code, description));
        public static WebServiceResult<T> Failure(string code, string? description = null)
            => new WebServiceResult<T>(StatusCodes.Status400BadRequest, false, default(T), new Error(code, description));
        public static WebServiceResult<T> Failure(IList<Error>? errors)
            => new WebServiceResult<T>(StatusCodes.Status400BadRequest, false, default(T), errors);
        public static WebServiceResult<T> Failure(int statusCode, IList<Error>? errors)
            => new WebServiceResult<T>(statusCode, false, default(T), errors);
    }
}
