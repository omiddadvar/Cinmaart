using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Abstractions.Notification
{
    public interface IEmailService
    {
        Task SendEmailAsync(string emailAddress, string subject, string htmlMessage);
    }
}
