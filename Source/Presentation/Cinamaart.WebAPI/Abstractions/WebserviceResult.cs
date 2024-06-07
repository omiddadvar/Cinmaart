

namespace Cinamaart.WebAPI.Abstractions
{
    public class WebserviceResult
    {
        public bool IsSuccess {  get; set; }
        public object? Data {  get; set; }
        public IEnumerable<WebserviceError>? Errors { get; set; } = null;
        public static WebserviceResult Success(object Data) => new WebserviceResult
        {
            IsSuccess = true,
            Data = Data
        };
        public static WebserviceResult Failure(IEnumerable<WebserviceError> Errors) => new WebserviceResult
        {
            IsSuccess = false,
            Data = null,
            Errors = Errors
        };
        public static WebserviceResult Failure(WebserviceError Error) => new WebserviceResult
        {
            IsSuccess = false,
            Data = null,
            Errors = new[] { Error }
        };
        public static WebserviceResult Failure(string Code, string Desc) => new WebserviceResult
        {
            IsSuccess = false,
            Data = null,
            Errors = new[] { new WebserviceError(Code, Desc) }
        };
    }

}
