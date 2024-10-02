namespace Cinamaart.Application.Abstractions.Services
{
    public interface IUrlService
    {
        string GenerateBaseUri();
        string GenerateEmailConfirmationUri(string userId, string token);
    }
}
