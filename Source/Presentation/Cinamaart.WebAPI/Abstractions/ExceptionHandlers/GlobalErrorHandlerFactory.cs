namespace Cinamaart.WebAPI.Abstractions.ExceptionHandlers
{
    public class GlobalErrorHandlerFactory
    {
        public static BaseGlobalExceptionHandler CreateHandler(Exception ex) => ex switch
        {
            _ => new BaseGlobalExceptionHandler(ex)
        };
    }
}
