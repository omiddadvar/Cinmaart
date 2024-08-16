using Cinamaart.Application.Abstractions.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
