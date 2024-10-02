using Cinamaart.Application.Abstractions.Notification;

namespace Cinamaart.Infrastructure.Services.Notification
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string emailAddress, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
