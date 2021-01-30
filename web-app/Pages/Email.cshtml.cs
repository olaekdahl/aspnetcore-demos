using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using web_app.Services;

namespace web_app.Pages
{
    public class EmailModel : PageModel
    {
        private IEmailService _email;
        public EmailModel(IEmailService email)
        {
            _email = email;
        }
        public void OnGet()
        {
            _email.SendEmail("ola@isinc.com", "Sending email....");
        }
    }
}
