using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Services
{
    public interface IEmail
    {
        void Send(string msg, string to);
    }

    public class Email : IEmail
    {
        public void Send(string msg, string to)
        {
            Debug.WriteLine($"{msg} sent to {to} from email place holder...");
        }
    }

    public class ProdEmail : IEmail
    {
        public void Send(string msg, string to)
        {
            Debug.WriteLine($"{msg} sent to {to} from prod email...");
        }
    }
}
