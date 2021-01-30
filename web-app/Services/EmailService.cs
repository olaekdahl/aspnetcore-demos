using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.Services
{
    public class EmailService : IEmailService
    {
        private string smtpServer;
        public EmailService(IOptionsSnapshot<EmailOptions> options)
        {
            smtpServer = options.Value.Server;
        }
        public void SendEmail(string to, string content)
        {
            Console.WriteLine($"Sending email to {to} with content {content} using server {smtpServer}");
        }
    }
}
