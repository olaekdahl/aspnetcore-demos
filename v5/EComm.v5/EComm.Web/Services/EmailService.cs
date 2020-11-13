using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string to, string content)
        {
            return true;
        }
    }

    public class EmailServiceImpl : IEmailService
    {
        public bool SendEmail(string to, string content)
        {
            if(content.Equals("test"))
            {
                return true;
            }
            return false;
        }
    }
}
