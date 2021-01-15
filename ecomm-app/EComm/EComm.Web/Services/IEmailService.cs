namespace EComm.Web.Services
{
    public interface IEmailService
    {
        void SendEmail(string email, string content);
    }
}