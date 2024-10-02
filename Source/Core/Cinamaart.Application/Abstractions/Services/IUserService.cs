namespace Cinamaart.Application.Abstractions.Services
{
    public interface IUserService
    {
        long? GetUserId();
        string? GetUserName();
    }
}
