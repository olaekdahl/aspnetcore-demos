namespace Ecomm.Web.Services
{
    public interface IEmailService
    {
        bool SendEmail(string toEmail, string content);
        string SendEmailWithStatus(string toEmail, string content);
    }
}