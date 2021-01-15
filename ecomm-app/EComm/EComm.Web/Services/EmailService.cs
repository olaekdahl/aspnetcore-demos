using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string email, string content)
        {
            Console.WriteLine($"Email sent to {email} with content {content}.");
        }
    }
}
