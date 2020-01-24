﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm.Web.Services
{
    public class EmailServiceStub : IEmailService
    {
        public bool SendEmail(string toEmail, string content)
        {
            return true;
        }

        public string SendEmailWithStatus(string toEmail, string content)
        {
            throw new NotImplementedException();
        }
    }
}