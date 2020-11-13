namespace EComm.Web.Services
{
    public interface IEmailService
    {
        bool SendEmail(string to, string content);
    }
}