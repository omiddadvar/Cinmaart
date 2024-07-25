namespace Cinamaart.WebAPI.Abstractions.ExceptionHandlerss
{
    public class GlobalErrorHandlerFactory
    {
        public static BaseGlobalExceptionHandler CreateHandler(Exception ex) => ex switch
        {
            _ => new BaseGlobalExceptionHandler(ex)
        };
    }
}
