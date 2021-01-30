namespace web_app.Services
{
    public interface IEmailService
    {
        void SendEmail(string to, string content);
    }
}