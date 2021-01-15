using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.Services
{
    public class SMTPEmailService : IEmailService
    {
        private string smtpServer;
        public SMTPEmailService(IOptions<EmailOptions> options)
        {
            smtpServer = options.Value.Server;
        }
        public void SendEmail(string email, string content)
        {
            Console.WriteLine($"Email sent to {email} with content {content} using server {smtpServer}.");
        }
    }
}
