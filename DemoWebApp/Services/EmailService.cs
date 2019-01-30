using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Services
{
    public class EmailConfig
    {
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
    public interface IEmailService
    {
        void SendEmail(string email, string msg, string server, string user, string pass);
    }
    public class EmailService : IEmailService
    {
        string _emailServer;
        string _user;
        public EmailService(IOptions<EmailConfig> configuration)
        {
            _emailServer = configuration.Value.Server;
            _user = configuration.Value.User;
        }

        public void SendEmail(string email, string msg, string server, string user, string pass)
        {
            Debug.WriteLine($"sending {msg} to {email}");
        }
    }

    public class EmailServiceProd : IEmailService
    {
        public void SendEmail(string email, string msg, string server, string user, string pass)
        {
            Debug.WriteLine($"sending {msg} from PRODUCTION to {email}");
        }
    }
}
