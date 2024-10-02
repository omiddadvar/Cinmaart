namespace Cinamaart.Application.Abstractions.Notification
{
    public interface IEmailService
    {
        Task SendEmailAsync(string emailAddress, string subject, string htmlMessage);
    }
}
